public class TaxFilingSystem
{
    private List<Person> _taxFilers = new List<Person>();
    private double _totalTaxCollected;

    //File tax for a person
    public void FileForPerson(Person person){
    // calculate and file fax for the person
    person.FileTax();
    // store the taxfile into list
    _taxFilers.Add(person);
    // increase the total amount of tax collected;
    _totalTaxCollected += person.TaxPaid;
    Console.WriteLine($"{person.Name} successfully paid ${person.TaxPaid} dollars.");
    }

    //return total tax collected
    public double GetTotalTaxCollected(){
        return _totalTaxCollected;
    }

    //return all tax files:
    public List<Person> GetAllTaxFilers(){
        return _taxFilers;
    }

    public void DisplayTaxRecords(){
        Console.WriteLine("\n=======  Tax Records  =======");
        Console.WriteLine("Total tax collect is "+ _totalTaxCollected + ".");
        foreach(var taxFiler in _taxFilers){
            Console.WriteLine($"{taxFiler.Name} paid ${taxFiler.TaxPaid}.");
        }
        Console.WriteLine("=======  Tax Records  =======\n");
        
    }
}