using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{

    public interface IListViewModel<T>
    {
        void GetAllFromListToListBox(List<T> list, ListBox listBox);
    }

    public class ViewModel : IListViewModel<ContenerModel>, IListViewModel<ShelfModel>, IListViewModel<ItemModel>
    {

        public void GetAllFromListToListBox(List<ContenerModel> list, ListBox listBox)
        {
            foreach (var item in list)
            {
                listBox.Items.Add(item.AsString);
            }
        }

        public void GetAllFromListToListBox(List<ShelfModel> list, ListBox listBox)
        {
            foreach (var item in list)
            {
                listBox.Items.Add(item.AsString);
            }
        }

        public void GetAllFromListToListBox(List<ItemModel> list, ListBox listBox)
        {
            foreach (var item in list)
            {
                listBox.Items.Add(item.AsString);
            }
        }
    }
}
