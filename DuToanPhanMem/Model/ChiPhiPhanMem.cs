using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DuToanPhanMem.Model
{
    class ChiPhiPhanMem:INotifyPropertyChanged
    {
        private long _giaTriPhanMem;
        private long _chiPhiChung;
        private long _thue;
        private long _tong;
        private bool _isChanged = false;

        public long GiaTriPhanMem
        {
            get { return this._giaTriPhanMem; }
            set
            {
                if (this._giaTriPhanMem != value)
                {
                    this._giaTriPhanMem = value;
                    Check();
                    OnPropertyChanged("GiaTriPhanMem");
                }
                    

            }
        }

        public long ChiPhiChung {
            get { return this._chiPhiChung; }
            set
            {
                if (this._chiPhiChung != value)
                {
                    this._chiPhiChung = value;
                    Check();
                    OnPropertyChanged("ChiPhiChung");
                }


            }
        }

        public long Thue {
            get { return this._thue; }
            set
            {
                if (this._thue != value)
                {
                    this._thue = value;
                    Check();
                    OnPropertyChanged("Thue");
                }


            }
        }

        public long Tong {
            get { return this._tong; }
            set
            {
                if (this._tong != value)
                {
                    this._tong = value;
                    OnPropertyChanged("Tong");
                }


            }
        }

        public bool IsChanged
        {
            get { return this._isChanged; }
            set
            {
                if (this._isChanged != value)
                {
                    this._isChanged = value;
                    OnPropertyChanged("IsChanged");
                }


            }
        }

        public void Check()
        {
            if (GiaTriPhanMem != 0 && ChiPhiChung != 0 && Thue != 0)
                IsChanged = true;
            else
                IsChanged = false;
        }

        public void TinhChiPhi()
        {
            Tong = GiaTriPhanMem + ChiPhiChung + Thue;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
