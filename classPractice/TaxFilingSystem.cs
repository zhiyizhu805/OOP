//person class containing infos:Name/annualIncom/Taxpaid

public class TaxFilingSystem
{
    private List<Person> _taxFilers = new List<Person>();
    private double _totalTaxCollected;

    //File tax for a person
    public void FileForPerson(Person person, TaxCalculator taxCalculator){
    // calculate and file fax for the person
    // taxCalculator.CalculateTax(person);
    person.FileTax(taxCalculator);
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
        foreach(var taxFiler in _taxFilers){
            Console.WriteLine($"{taxFiler.Name} paid ${taxFiler.TaxPaid}.");
        }
    }
}