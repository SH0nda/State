using System;

namespace Test
{
	class main
	{
		public static void Main(string[] args)
		{
			Dog pochi = new Dog();
			pochi.jyoutaiNani();

			pochi.roudou();
			pochi.jyoutaiNani();

			pochi.roudou();
			pochi.jyoutaiNani();

			pochi.roudou();
			pochi.jyoutaiNani();

			pochi.roudou();
			pochi.jyoutaiNani();

			pochi.shokuji();
			pochi.jyoutaiNani();

			pochi.shokuji();
			pochi.jyoutaiNani();

			Console.ReadLine();
		}
	}

	public class Dog
	{
		private DogState myState;

		public Dog()
		{
			myState = TanoshiiState.getInstance();
		}

		public void roudou()
		{
			myState.tukareta(this);
		}

		public void shokuji()
		{
			myState.tabeta(this);
		}
		
		public void changeState(DogState d)
		{
			myState = d;
		}

		public void jyoutaiNani()
		{
			Console.Write("現在、私は「");
			Console.Write(myState.toString());
			Console.WriteLine("」です。");
		}
	}

	public abstract class DogState
	{
		public abstract void tukareta(Dog yobidashimoto);
		public abstract void tabeta(Dog yobidashimoto);
		public abstract string toString();
	}

	class TanoshiiState : DogState
	{
		public static TanoshiiState s = new TanoshiiState();
		public TanoshiiState() { }

		public static DogState getInstance()
		{
			return s;
		}

		public override void tukareta(Dog moto)
		{
			moto.changeState(FutsuuState.getInstance());
		}

		public override void tabeta(Dog moto) { }

		public override string toString()
		{
			return "楽しい状態";
		}
	}

	class FutsuuState : DogState
	{
		private static FutsuuState s = new FutsuuState();
		private FutsuuState() { }

		public static DogState getInstance()
		{
			return s;
		}

		public override void tukareta(Dog moto)
		{
			moto.changeState(IrairaState.getInstance());
		}

		public override void tabeta(Dog moto)
		{
			moto.changeState(TanoshiiState.getInstance());
		}

		public override string toString()
		{
			return "普通状態";
		}
	}

	class IrairaState : DogState
	{
		private static IrairaState s = new IrairaState();
		private IrairaState() { }

		public static DogState getInstance()
		{
			return s;
		}

		public override void tukareta(Dog moto)
		{
			moto.changeState(ByoukiState.getInstance());
		}

		public override void tabeta(Dog moto)
		{
			moto.changeState(TanoshiiState.getInstance());
		}

		public override string toString()
		{
			return "いらいら状態";
		}
	}

	class ByoukiState : DogState
	{
		private static ByoukiState s = new ByoukiState();
		private ByoukiState() { }

		public static DogState getInstance()
		{
			return s;
		}

		public override void tukareta(Dog moto) { }

		public override void tabeta(Dog moto)
		{
			moto.changeState(FutsuuState.getInstance());
		}

		public override string toString()
		{
			return "病気状態";
		}
	}
}
