using System.Collections.ObjectModel;
using Vakcina.API.Models;
using Vakcina.WPF.Repositories;

namespace Vakcina.WPF.ViewModels
{
    public class OltasViewModel : PagerViewModel
    {
        private readonly OltasRepository _repository;
        public OltasViewModel(OltasRepository repository)
        {
            _repository = repository;
            LoadData();
        }

        private ObservableCollection<oltas> _oltasok = default!;
        public ObservableCollection<oltas> Oltasok
        {
            get { return _oltasok; }
            set { SetProperty(ref _oltasok, value); }
        }

        protected override void LoadData()
        {
            var query = _repository.GetAll(page, ItemsPerPage, SearchKey, SortBy, ascending);
            TotalItems = _repository.TotalItems;
            Oltasok = new ObservableCollection<oltas>(query);
        }
    }
}
