namespace SimpleCalculator;

public partial class MainPage : ContentPage
{
	double currentNumber, previousNumber;
	bool isNewNumberStart = false;
	string mathOperator;

	public MainPage()
	{
		InitializeComponent();
	}

	void OnClear(object sender, EventArgs e)
	{
		currentNumber = 0;
		previousNumber = 0;
		mathOperator = null;
		isNewNumberStart = false;
		resultLabel.Text = "0";
	}

	void OnSelectNumber(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		string pressed = button.Text;

		if (isNewNumberStart || (resultLabel.Text == "0" && mathOperator == null))
		{
			resultLabel.Text = "";
			isNewNumberStart = false;
		}

		resultLabel.Text += pressed;

		double.TryParse(resultLabel.Text, out currentNumber);
	}

	void OnSelectOperator(object sender, EventArgs e)
	{
		if (mathOperator != null)
		{
			OnCalculate(sender, e);
		}
		else
		{
			previousNumber = currentNumber;
		}
		
		Button button = (Button)sender;
		mathOperator = button.Text;
		isNewNumberStart = true;
	}

	void OnCalculate(object sender, EventArgs e)
	{
		if (double.TryParse(resultLabel.Text, out double newNumber))
		{
			currentNumber = mathOperator switch
			{
				"+" => previousNumber + newNumber,
				"-" => previousNumber - newNumber,
				"*" => previousNumber * newNumber,
				"/" => newNumber != 0 ? previousNumber / newNumber : throw new DivideByZeroException(),
				_ => currentNumber
			};

			resultLabel.Text = currentNumber.ToString();
			
			if (sender == equalButton)
			{
				mathOperator = null;
			}
		}
	}
	
}

