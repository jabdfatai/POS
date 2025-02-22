using POSLib.Model;
using POSLib.ViewModel;
using POSWPFSaleProject.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWPFSaleProject.ViewModel
{
    public class SalesViewModel : ViewModelBase
    {

        public ObservableCollection<PosScanOperationViewModel> posscanentries { get; set; }

        //  public RelayCommand AddCommand => new RelayCommand(execute => { }, canExecute => { return true; });
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());



        public SalesViewModel()
        {
            posscanentries  = new ObservableCollection<PosScanOperationViewModel>();
            ScanProduct();
           
        }

        private PosScanOperationViewModel selectedScanEntry;

        public PosScanOperationViewModel SelectedScanEntry
        {
            get { return selectedScanEntry; }
            set
            {
                selectedScanEntry = value;
                OnPropertyChanged();
            }
        }

        void AddItem()
        {
            posscanentries.Add(new PosScanOperationViewModel 
            {  id = 1, 
                scandate = DateTime.Now,
                source = 1, scantime = "10:00",
                item_name = "Okin Biscuit",
                unit_price = 100,
                quantity = 2,
                line_total = 200,
                tranxid = "ord_0098",
                UPC = "009878" });
        }

        bool ScanProduct()
        {
            posscanentries.Add(new PosScanOperationViewModel
            {
                id = 1,
                scandate = DateTime.Now,
                source = 1,
                scantime = "10:00",
                item_name = "Okin Biscuit",
                unit_price = 100,
                quantity = 2,
                line_total = 200,
                tranxid = "ord_0098",
                UPC = "009878"
            });
            return true;
        }


       public string SearchProducts()
        {
            return "Hello";
        }
    }
}
