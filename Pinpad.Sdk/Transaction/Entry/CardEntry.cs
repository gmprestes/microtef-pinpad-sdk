﻿using Pinpad.Sdk.Transaction.TypeCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pinpad.Sdk.Transaction.Entry
{
    /// <summary>
    /// Represents a physical card used to perform a transaction.
    /// </summary>
    public class CardEntry
    {
        /// <summary>
        /// Card type, defining the reading method (by EMV chip or magnetic stripe) to be used by the application.
        /// </summary>
        public CardType Type { get; set; }
        /// <summary>
        /// Card brand (for example Visa, MasterCard, Amex, etc).
        /// </summary>
        public int BrandId { get; set; }
        /// <summary>
        /// Unmasked pan, all characters shown.
        /// </summary>
        public string PrimaryAccountNumber { get; set; }
        /// <summary>
        /// Card expiration date, printed in the original physical card.
        /// </summary>
        public DateTime ExpirationDate { get; set; }
        /// <summary>
        /// Cardholder/card owner name, printed in the original physical card.
        /// </summary>
        public string CardholderName { get; set; }
        /// <summary>
        /// First track of card, if exists.
        /// </summary>
        public string Track1 { get; set; }
        /// <summary>
        /// Second track of card, if exists.
        /// </summary>
        public string Track2 { get; set; }
        /// <summary>
        /// Third track of card, if exists.
        /// </summary>
        public string Track3 { get; set; }
    }
}