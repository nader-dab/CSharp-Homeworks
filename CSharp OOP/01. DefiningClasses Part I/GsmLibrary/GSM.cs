namespace GsmLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GSM
    {
        private static GSM iphone4S = new GSM("Iphone 4S", "Apple", 699.99m, "Steve Jobs", "Iphone battery", BatteryType.NiMH, "12:00:00", "18:00:00", 4.5f, 16000);
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery batteryCharacteristics = new Battery();
        private Display displayCharacteristics = new Display();
        private List<Call> callHistory = new List<Call>();

        public GSM(string model, string manufacturer)
            : this(model, manufacturer, 0, null)
        {
        }

        public GSM(
            string model, 
            string manufacturer, 
            decimal price, 
            string owner,
            string batteryModel = null, 
            BatteryType type = (BatteryType)0, 
            string hoursTalk = "00:00:00", 
            string hoursIdle = "00:00:00", 
            float displaySize = 0, 
            int displayColors = 0)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.batteryCharacteristics = new Battery(batteryModel, type, hoursIdle, hoursTalk);
            this.displayCharacteristics = new Display(displaySize, displayColors);
        }

        public static GSM Iphone4S
        {
            get
            {
                return iphone4S;
            }

            private set
            {
                iphone4S = value;
            }
        }

        public string CallHistory 
        {
            get 
            {
                StringBuilder sb = new StringBuilder();
                foreach (var calls in this.callHistory)
                {
                    sb.AppendLine(calls.ToString());
                }

                if (string.IsNullOrEmpty(sb.ToString()))
                {
                    return "[Call history is Empty]";
                }

                return sb.ToString();
            }
        }

        public Display DisplayCharacteristics
        {
            get
            {
                return this.displayCharacteristics;
            }

            set 
            {
                this.displayCharacteristics = value;
            }
        }

        public Battery BatteryCharacteristics
        {
            get
            {
                return this.batteryCharacteristics;
            }

            set
            {
                this.batteryCharacteristics = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                this.owner = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid GSM price");
                }

                this.price = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                this.manufacturer = value;
            }
        }

        public string Model
        {
            get 
            {
                return this.model; 
            }

            set 
            {
                this.model = value;
            }
        }

        public void AddCall(DateTime date = default(DateTime), string phone = null, int duration = 0)
        {
            this.callHistory.Add(new Call(date, phone, duration));
        }

        public void DeleteCall(int callIndex)
        {
            if (callIndex < 0 || callIndex > this.callHistory.Count - 1)
            {
                throw new ArgumentException(string.Format("Invalid call removal. Index must be greater than 0 and smaller than {0}.", this.callHistory.Count - 1));
            }

            this.callHistory.RemoveAt(callIndex);
        }

        public void ClearCallHistory()
        {
            this.callHistory = new List<Call>();
        }

        public decimal TotalPrice(decimal pricePerMin = 0.37m)
        {
            decimal cost = 0;
            foreach (var call in this.callHistory)
            {
                cost += (decimal)call.Duration / 60m * pricePerMin;
            }

            return cost;
        }

        public void RemoveLongestCall()
        {
            if (this.callHistory.Count == 0)
            {
                return;
            }

            this.callHistory = this.callHistory.OrderByDescending(x => x.Duration).ToList();
            this.callHistory.RemoveAt(0);
        }

        public override string ToString()
        {
            string information = string.Format(
                "---GSM--- \nModel: {0} \nManufacturer: {1} \nPrice: {2}$ \nOwner: {3} \n---Battery Information--- \n{4} \n---Display Information--- \n{5}", 
                this.model, 
                this.manufacturer, 
                this.price, 
                this.owner, 
                this.batteryCharacteristics.ToString(), 
                this.displayCharacteristics.ToString());

            return information;
        }
    }
}
