using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace SaaUI
{
    public class SaaHeightOffset:SaaNotifier
    {
        public SaaHeightOffset()
        {

        }
        public SaaHeightOffset(int All)
        {
            this.All = All;
        }
        public SaaHeightOffset(int Top, int Bottom)
        {
            this.Top = Top;
            this.Bottom = Bottom;
        }
        int _All = 0;
        public int All
        {
            get
            {
                return Top + Bottom;
            }
            set
            {
                Top = Bottom = value;
                Notify();
            }
        }
        int _Top = 0;
        public int Top {
            get
            {
                return _Top;
            }
            set
            {
                _Top = value;
                Notify();
            }
        }
        int _Bottom = 0;
        public int Bottom
        {
            get
            {
                return _Bottom;
            }
            set
            {
                _Bottom = value;
                Notify();
            }
        }
    }
    public class SaaWidthOffset : SaaNotifier
    {
        public SaaWidthOffset()
        {

        }
        public SaaWidthOffset(int All)
        {
            this.All = All;
        }
        public SaaWidthOffset(int Right, int Left)
        {
            this.Right = Right;
            this.Left = Left;
        }

        public int All
        {
            get
            {
                return Right + Left;
            }
            set
            {
                Right = Left = value;
                Notify();
            }
        }
        int _Right = 0;
        public int Right
        {
            get
            {
                return _Right;
            }
            set
            {
                _Right = value;
                Notify();
            }
        }
        int _Left = 0;
        public int Left
        {
            get
            {
                return _Left;
            }
            set
            {
                _Left = value;
                Notify();
            }
        }
    }
}
