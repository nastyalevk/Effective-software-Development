<Query Kind="Program" />

class Client
{ 
	public string name;
	public Deposite [] deposite;
	public Client(string name, params Deposite [] deposite)
	{
		this.name=name;
		this.deposite=deposite;
	}
}
abstract class Deposite
{
	public Deposite(string n, double count )
	{
		this.Name = n;
		this.count=count;
	}
	public string Name { get; protected set; }
	public double count {get;set;}
	public abstract double GetDollar();
	public abstract double GetEuro();
	public abstract double GetRuble();
}

class EuroDeposite : Deposite
{
	public EuroDeposite(double count) : base("Депозит в евро", count)
	{
		this.count = count;
	}
	public override double GetDollar()
	{
		return count * 1.13;
	}
	public override double GetEuro()
	{
		return count;
	}
	public override double GetRuble()
	{
		return count * 2.42;
	}
}
class DollarDeposite : Deposite
{
	public DollarDeposite(double count) : base("Депозит в долларах", count)
	{ this.count = count;}
	public override double GetDollar()
	{
		return count;
	}
	public override double GetEuro()
	{
		return count * 0.88;
	}
	public override double GetRuble()
	{
		return count * 2.13;
	}
}
class RubleDeposite : Deposite
{
	public RubleDeposite(double count) : base("Депозит в рублях", count)
	{this.count = count; }
	public override double GetDollar()
	{
		return count * 0.47 ;
	}
	public override double GetEuro()
	{
		return count * 0.41;
	}
	public override double GetRuble()
	{
		return count;
	}
}
static class Funk
{
	public static double SummAllInDollarForClient(Client client)
	{
		double result = 0;
		for (int i = 0; i < client.deposite.Count(); i++)
		{
			result += client.deposite[i].GetDollar();
		}
		return result;
	}
	public static string SummAllInValues(params Client[] clients)
	{
		double euro = 0;
		double dollar = 0;
		double ruble = 0;
		for(int j = 0; j<clients.Count(); j++)
		{
			for (int i = 0; i < clients[j].deposite.Count(); i++)
			{
				switch (clients[j].deposite[i].Name)
				{
					case "Депозит в евро":
						{
							euro = euro + clients[j].deposite[i].GetEuro();
							break;
						}
					case "Депозит в долларах":
						{
							dollar = dollar + clients[j].deposite[i].GetDollar();
							break;
						}
					case "Депозит в рублях":
						{
							ruble = ruble + clients[j].deposite[i].GetRuble();
							break;
						}
				}
			}
		}
		return String.Format("Евро {0}, доллар {1}, рубль {2}", euro, dollar, ruble);
		
	}
	private static double MinDepositeClient(Client client)
	{
		double min = client.deposite[0].GetDollar(), minIndex = 0;
		for (int j = 0; j < client.deposite.Count(); j++)
		{
			if (min > client.deposite[j].GetDollar())
			{
				min =  client.deposite[j].GetDollar();
				minIndex = j;
			}
		}
		return min;
	}
	private static double MaxDepositeClient(Client client)
	{
		double max = client.deposite[0].GetDollar(), maxIndex = 0;
		for (int j = 0; j < client.deposite.Count(); j++)
		{
			if (max < client.deposite[j].GetDollar())
			{
				max = client.deposite[j].GetDollar();
				maxIndex = j;
			}
		}
		return max;
	}
	public static string MaxDepositeAllClients(params Client[] clients)
	{
		Client max = clients[0];
		double maxIndex = 0;
		for (int i = 0; i < clients.Count(); i++)
		{
			if (MaxDepositeClient(max) < MaxDepositeClient(clients[i]))
			{
				max = clients[i];
				maxIndex = i;
			}
		}
		return max.name;
	}
	public static string MinDepositeAllClients(params Client[] clients)
	{
		Client min = clients[0];
		double minIndex = 0;
		for (int i = 0; i < clients.Count(); i++)
		{
			if (MaxDepositeClient(min) > MaxDepositeClient(clients[i]))
			{
				min = clients[i];
				minIndex = i;
			}
		}
		return min.name;
	}
}