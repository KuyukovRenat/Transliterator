﻿using System;
using System.Collections.Generic;
using System.Text;

namespace nsLex
{
    public enum TState { Start, Continue, Finish }; //тип состояния
    public enum TCharType { Letter, Digit, EndRow, EndText, Space, ReservedSymbol }; // тип символа
    public enum TToken { lxmIdentifier, lxmNumber, lxmUnknown, lxmEmpty, lxmLeftParenth, lxmRightParenth, lxmIs, lxmDot, lxmComma, lxmText, lxmtz, lxmdt, lxmr, lxmrs, lxmls };
    public class CLex  //класс лексический анализатор
    {
        private String[] strFSource;  // указатель на массив строк
        private String[] strFMessage;  // указатель на массив строк
        public TCharType enumFSelectionCharType;
        public char chrFSelection;
        private TState enumFState;
        private int intFSourceRowSelection;
        private int intFSourceColSelection;
        private String strFLexicalUnit;
        private TToken enumFToken;
        public String[] strPSource { set { strFSource = value; } get { return strFSource; } }
        public String[] strPMessage { set { strFMessage = value; } get { return strFMessage; } }
        public TState enumPState { set { enumFState = value; } get { return enumFState; } }
        public String strPLexicalUnit { set { strFLexicalUnit = value; } get { return strFLexicalUnit; } }
        public TToken enumPToken { set { enumFToken = value; } get { return enumFToken; } }
        public int intPSourceRowSelection { get { return intFSourceRowSelection; } set { intFSourceRowSelection = value; } }
        public int intPSourceColSelection { get { return intFSourceColSelection; } set { intFSourceColSelection = value; } }
        public void GetSymbol(bool comm = false) //метод класса лексический анализатор
        {
            intFSourceColSelection++; // продвигаем номер колонки
            if (intFSourceColSelection > strFSource[intFSourceRowSelection].Length - 1)
            {
                intFSourceRowSelection++;
                if (intFSourceRowSelection <= strFSource.Length - 1)
                {
                    intFSourceColSelection = -1;
                    chrFSelection = '\0';
                    enumFSelectionCharType = TCharType.EndRow;
                    enumFState = TState.Continue;
                }
                else
                {
                    chrFSelection = '\0';
                    enumFSelectionCharType = TCharType.EndText;
                    enumFState = TState.Finish;

                }
            }
            else
            {
                chrFSelection = strFSource[intFSourceRowSelection][intFSourceColSelection]; //классификация прочитанной литеры
                if (chrFSelection == ' ') enumFSelectionCharType = TCharType.Space;
                else if (chrFSelection >= 'a' && chrFSelection <= 'd') enumFSelectionCharType = TCharType.Letter;
                else if (chrFSelection == '0' || chrFSelection == '1') enumFSelectionCharType = TCharType.Digit;
                else if (chrFSelection == '/') enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (chrFSelection == '*') enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (chrFSelection == '|') enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (chrFSelection == '(' || chrFSelection == ')' || chrFSelection == ':' || chrFSelection == '-' || chrFSelection == ',' || chrFSelection == '.') enumFSelectionCharType = TCharType.ReservedSymbol;
                else throw new System.Exception("Cимвол вне алфавита");
                enumFState = TState.Continue;
            }

        }
        private void TakeSymbol()
        {
            char[] c = { chrFSelection };
            String s = new string(c);
            strFLexicalUnit += s;
            GetSymbol();
        }
        public void NextToken()
        {
            strFLexicalUnit = "";
            if (enumFState == TState.Start)
            {
                intFSourceRowSelection = 0;
                intFSourceColSelection = -1;
                GetSymbol();
            }
            while (enumFSelectionCharType == TCharType.Space || enumFSelectionCharType == TCharType.EndRow)
            {
                GetSymbol();
            }
            if (chrFSelection == '/')
            {
                GetSymbol();
                if (chrFSelection == '/')
                    while (enumFSelectionCharType != TCharType.EndRow)
                    {
                        GetSymbol();
                    }
                GetSymbol();
            }
            // Вариант 12
            switch (enumFSelectionCharType)
            {
                case TCharType.Letter:
                    {
                    //         a    b    c    d
                    //   A   | B  | C  | C  | C  |
                    //   B   |BFin|    |    |    |
                    //  CFin |CFin|CFin|CFin|CFin|
                    A:
                        {
                            if (chrFSelection == 'a')
                            {
                                TakeSymbol();
                                goto BFin;
                            }
                            else
                            {
                                TakeSymbol();
                                goto CFin;
                            }
                        }
                    BFin:
                        {
                            if (chrFSelection == 'a')
                            {
                                TakeSymbol();
                                goto BFin;
                            }
                            else if (chrFSelection == 'b' || chrFSelection == 'c' || chrFSelection == 'd')
                                throw new Exception("Если начинается с'a', то продолжается ‘a’");
                            else
                            {
                                enumFToken = TToken.lxmIdentifier;
                                return;
                            }
                        }
                    CFin:
                        {
                            if (chrFSelection == 'a' || chrFSelection == 'b' || chrFSelection == 'c' || chrFSelection == 'd')
                            {
                                TakeSymbol();
                                goto CFin;
                            }
                            else
                            {
                                enumFToken = TToken.lxmIdentifier;
                                return;
                            }
                        }
                    }
                    if (chrFSelection == '/')
                    {
                        GetSymbol();
                        if (chrFSelection == '/')
                            while (enumFSelectionCharType != TCharType.EndRow)
                            {
                                GetSymbol();
                            }
                        GetSymbol();
                    }
                case TCharType.Digit:
                    {
                    //           0     1  
                    //    A   |  B  |  D  |
                    //    B   |  C  |     |
                    //    C   |     |  A  |
                    //    D   |  E  |     |
                    //    E   |FFin |     |
                    //   FFin |     |  G  |
                    //    G   |  H  |     |
                    //    H   |     |FFin |

                        A:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto B;
                        }
                        else if (chrFSelection == '1')
                        {
                            TakeSymbol();
                            goto D;
                        }
                        else throw new Exception("Ожидался 0 или 1");

                        B:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto C;
                        }
                        else throw new Exception("Ожидался 0");

                        C:
                        if (chrFSelection == '1')
                        {
                            TakeSymbol();
                            goto A;
                        }
                        else throw new Exception("Ожидался 1");

                        D:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto E;
                        }
                        else throw new Exception("Ожидался 0");

                        E:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto FFin;
                        }
                        else throw new Exception("Ожидался 0");

                        FFin:
                        if (chrFSelection == '1')
                        {
                            TakeSymbol();
                            goto G;
                        }
                        else if (enumFSelectionCharType != TCharType.Digit) { enumFToken = TToken.lxmNumber; return; }
                        else throw new Exception("Ожидалась 1");

                        G:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto H;
                        }
                        else throw new Exception("Ожидался 0");


                        H:
                        if (chrFSelection == '1')
                        {
                            TakeSymbol();
                            goto FFin;
                        }
                        else throw new Exception("Ожидался 1");

                    }
                case TCharType.ReservedSymbol:
                    {
                        if (chrFSelection == '/')
                        {
                            GetSymbol();
                            if (chrFSelection == '/')
                            {
                                while (enumFSelectionCharType != TCharType.EndRow)
                                    GetSymbol(true);
                            }
                            GetSymbol();
                        }
                        if (chrFSelection == '(')
                        {
                            enumFToken = TToken.lxmLeftParenth;
                            GetSymbol();
                            return;
                        }
                        if (chrFSelection == ')')
                        {
                            enumFToken = TToken.lxmRightParenth;
                            GetSymbol();
                            return;
                        }
                        if (chrFSelection == '[')
                        {
                            enumFToken = TToken.lxmls;
                            GetSymbol();
                            return;
                        }
                        if (chrFSelection == ']')
                        {
                            enumFToken = TToken.lxmrs;
                            GetSymbol();
                            return;
                        }
                        if (chrFSelection == ',')
                        {
                            enumFToken = TToken.lxmComma;
                            GetSymbol();
                            return;
                        }
                        if (chrFSelection == ':')
                        {
                            enumFToken = TToken.lxmdt;
                            GetSymbol();
                            return;
                        }
                        if (chrFSelection == '=')
                        {
                            enumFToken = TToken.lxmr;
                            GetSymbol();
                            return;
                        }

                        break;
                    }
                case TCharType.EndText:
                    {
                        enumFToken = TToken.lxmEmpty;
                        break;
                    }

                 case TCharType.Space:
                    {
                        GetSymbol();
                        break;
                    }
            }
        }
    }
}


