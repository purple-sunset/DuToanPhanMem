﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace DuToanPhanMem.Model
{
    public class HeSoPhucTapKTCN:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private GiaTriPhanMem _gt;

        private ObservableCollection<HeSoKT> _ds = new ObservableCollection<HeSoKT>();

        private float _tfw;
        private float _tcf;
        

        private static readonly float TOLERANCE = 0.05f;

        public ObservableCollection<HeSoKT> DS
        {
            get { return _ds; }
            set {
                if (this._ds != value)
                {
                    this._ds = value;
                    OnPropertyChanged("DS");
                          
                }
            }
        }

        public float TCF
        {
            get { return _tcf; }
            set
            {
                if (Math.Abs(this._tcf - value) > TOLERANCE)
                {
                    this._tcf = value;
                    OnPropertyChanged("TCF");
                    _gt.TCF = value;
                }
            }
        }

        public float TFW
        {
            get { return _tfw; }
            set
            {
                if (Math.Abs(this._tfw - value) > TOLERANCE)
                {
                    this._tfw = value;
                    OnPropertyChanged("TFW");
                }
            }
        }

        

        public HeSoPhucTapKTCN(GiaTriPhanMem gt)
        {
            _gt = gt;
            HeSoKT.hs = this;
            DS.Add(new HeSoKT(0,0,0));
            DS.Add(new HeSoKT(1, 0, 0));
            DS.Add(new HeSoKT(2, 0, 0));
            DS.Add(new HeSoKT(3, 0, 0));
            DS.Add(new HeSoKT(4, 0, 0));
            DS.Add(new HeSoKT(5, 0, 0));
            DS.Add(new HeSoKT(6, 0, 0));
            DS.Add(new HeSoKT(7, 0, 0));
            DS.Add(new HeSoKT(8, 0, 0));
            DS.Add(new HeSoKT(9, 0, 0));
            DS.Add(new HeSoKT(10, 0, 0));
            DS.Add(new HeSoKT(11, 0, 0));
            DS.Add(new HeSoKT(12, 0, 0));

        }



        public void TinhTFW()
        {
            TFW = DS.Sum(a => a.KetQua);
        }

        public void TinhTCF()
        {
            TinhTFW();
            TCF = 0.6f + 0.01f * TFW;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class HeSoKT:INotifyPropertyChanged
    {
        public static HeSoPhucTapKTCN hs;
        private int _chiSo;
        private int _xepHang;
        private float _ketQua;
        
        private static readonly float TOLERANCE = 0.05f;

        public int ChiSo
        {
            get { return _chiSo; }
            set { _chiSo = value; }
        }

        public int XepHang
        {
            get { return _xepHang; }
            set
            {
                if (this._xepHang != value)
                {
                    this._xepHang = value;
                    OnPropertyChanged(nameof(XepHang));
                    TinhKetQua();
                    hs.TinhTCF();
                }
            }
        }

        public float KetQua
        {
            get { return _ketQua; }
            set
            {
                if (Math.Abs(this._ketQua - value) > TOLERANCE)
                {
                    this._ketQua = value;
                    OnPropertyChanged(nameof(KetQua));
                }
            }
        }

        

        public HeSoKT(int chiso, int xephang, float ketqua)
        {
            ChiSo = chiso;
            XepHang = xephang;
            KetQua = ketqua;
        }

        

        public void TinhKetQua()
        {
            switch (ChiSo)
            {
                case 0:
                    KetQua = 2 * XepHang;
                    break;
                case 5:
                    KetQua = 0.5f * XepHang;
                    break;
                case 6:
                    KetQua = 0.5f * XepHang;
                    break;
                case 7:
                    KetQua = 2 * XepHang;
                    break;
                default:
                    KetQua = XepHang;
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
