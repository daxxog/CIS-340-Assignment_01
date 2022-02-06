/* ================================================
 * @author     David Volm aka VOLMINATOR aka daXXog
 * @date       Sat Feb  5 17:32:12 CST 2022
 * @school     UWSP
 * @class      CIS 340
 * @section    01
 * @assignment 01
 * @professor  Hardeep Kaur Dhalla
 * @licence    MIT
 * ===============================================*/


namespace HardwareStore {
    class Invoice {
        // constants
        public const string DEFAULT_PART_DESCRIPTION = "";
        public const int DEFAULT_QUANTITY = 0;
        public const decimal DEFAULT_PRICE = 0.00m;
        public const decimal DEFAULT_INVOICE_AMOUNT = DEFAULT_QUANTITY * DEFAULT_PRICE;

        // fields
        private int _quantity = DEFAULT_QUANTITY;
        private decimal _price = DEFAULT_PRICE;
        private bool _invoiceAmountCached = true;
        private decimal _invoiceAmount = DEFAULT_INVOICE_AMOUNT;

        // properties
        public string PartNumber { get; set; }
        public string PartDescription { get; set; }

        public int Quantity {
            get {
                return _quantity;
            }
            set {
                // if value changed force recalculation of invoice amount
                if (value != _quantity) {
                    _invoiceAmountCached = false;
                }

                if (value >= 0) {
                    _quantity = value;
                }
            }
        }

        public decimal Price {
            get {
                return _price;
            }
            set {
                // if value changed force recalculation of invoice amount
                if (value != _price) {
                    _invoiceAmountCached = false;
                }

                if (value >= 0) {
                    _price = value;
                }
            }
        }

        public decimal InvoiceAmount {
            get {
                if (_invoiceAmountCached) {
                    return _invoiceAmount;
                } else {
                    _invoiceAmount = _calcInvoiceAmount(
                        quantity: Quantity,
                        price: Price
                    );
                    _invoiceAmountCached = true;

                    return _invoiceAmount;
                }
            }
        }


        // constructor
        public Invoice(
            string partNumber, // required
            string partDescription = DEFAULT_PART_DESCRIPTION,
            int quantity = DEFAULT_QUANTITY,
            decimal price = DEFAULT_PRICE
        ) {
            PartNumber = partNumber;
            PartDescription = partDescription;
            Quantity = quantity;
            Price = price;
        }


        // methods
        private static decimal _calcInvoiceAmount(
            int quantity,
            decimal price
        ) {
            // if changing the invoice calculation method,
            // also change DEFAULT_INVOICE_AMOUNT to reflect this
            return quantity * price;
        }

        public decimal GetInvoiceAmount() {
            return InvoiceAmount;
        }
    }
}
