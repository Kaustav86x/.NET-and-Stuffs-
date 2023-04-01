/*using System;*/
namespace InsuranceDetails
{
	public class Insurance
	{
		private string insuraneNo;
		private string insuranceName;
		private double amountCovered;

		public string InsuranceNO
		{
			get { return this.insuranceNo; }
			set { this.insuraneNo = value; }
		}
		public string InsuranceName
		{
			get { return this.insuranceName; }
			set { this.insuraneName = value; }
		}

		public double AmountCovered
		{
			get { return this.amountCovered; }
			set { this.amountCovered = value; }
		}
		// default constructor
		public Insurance()
		{

		}
		// parameterized Constructor
		public Insurance(string insuranceNo, string insuranceName, double amountCovered)
		{
			InsuranceNo = insuranceNo;
			InsuranceName = insuranceName;
			AmountCovered = amountCovered;
		}

		public virtual double calculatePremium()
		{
			return 0;
		}
	}

	class MotorInsurance : Insurance
	{
		private double idv;
		private float depPercent;

		public double Idv
		{
			get { return this.idv; }
			set { this.idv = value; }
		}
		public float DepPercent
		{
			get { return this.depPercent; }
			set { this.depPercent = value; }
		}

		public MotorInsurance()
		{

		}
		public MotorInsurance(string insuranceNo, string insuranceName, double amountCovered, float depPercent) : base(depPercent)
		{
			Idv = idv;
			InsuranceNO = insuranceNo;
			InsuranceName = insuranceName;
			AmountCovered = amountCovered;
			DepPercent = depPercent;
		}

		public override double calculatePremium()
		{
			double Mpremimum;
			Idv = (AmountCovered - (AmountCovered * DepPercent) / 100);
			Mpremium = (Idv * 3) / 100;
			return Mpremimum;
		}
	}

	class LifeInsurance : Insurance
	{
		private int policyTerms;
		private float benefitPercentage;

		public int PolicyTerms
		{
			get { return this.policyTerms; }
			set { this.policyTerms = value; }
		}

		public float BenefitPercentage
		{
			get { return this.benefitPercentage; }
			set { this.benefitPercentage = value; }
		}

		public LifeInsurance(string insuranceNo, string insuranceName, double amountCovered, int policyTerms, float benefitPrecentage) : base(policyTerms, benefitPrecentage)
		{
			PolicyTerms = policyTerms;
			BenefitPercentage = benefitPrecentage;
		}

		public override double calculatePremium()
		{
			double Lpremimum;
			Lpremimum = (AmountCovered - ((AmountCovered * BenefitPercentage) / 100)) / policyTerms;
			return Lpremimum;
		}
	}
}
