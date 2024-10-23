using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataExample.Models;

public abstract class Base
{

}

public class Customer : Base, INotifyPropertyChanged
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedOn { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    private Customer()
    {
        
    }

    private bool isRemoved;

    public void Remove()
    {
        SoftDelete();
    }

    private void SoftDelete()
    {
        isRemoved = true;
    }

    

}
