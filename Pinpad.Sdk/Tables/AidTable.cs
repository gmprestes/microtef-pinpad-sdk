﻿using Pinpad.Sdk.Commands;
using Pinpad.Sdk.PinpadProperties.Refactor.Formatter;
using Pinpad.Sdk.PinpadProperties.Refactor.Parser;
using Pinpad.Sdk.PinpadProperties.Refactor.Property;
using System;

namespace Pinpad.Sdk 
{
	/// <summary>
	/// EMV Application IDentifier table record
	/// </summary>
	public sealed class AidTable : BaseAidTable 
	{
        /// <summary>
		/// Application standard
		/// </summary>
		public override ApplicationType T1_ICCSTD
        {
            get
            {
                return ApplicationType.IccEmv;
            }
        }
        /// <summary>
        /// First option for terminal application version number
        /// If the application version at terminal does not match any of the terminal application versions the bit 8 of byte 2 from Terminal Verification Result will be set
        /// EMV TAG 9F09h
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_APPVER1 { get; private set; }
        /// <summary>
        /// Second option for terminal application version number
        /// If the application version at terminal does not match any of the terminal application versions the bit 8 of byte 2 from Terminal Verification Result will be set
        /// EMV TAG 9F09h
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_APPVER2 { get; private set; }
        /// <summary>
        /// Third option for terminal application version number
        /// If the application version at terminal does not match any of the terminal application versions the bit 8 of byte 2 from Terminal Verification Result will be set
        /// EMV TAG 9F09h
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_APPVER3 { get; private set; }
        /// <summary>
        /// Terminal Country Code
        /// EMV TAG 9F1Ah
        /// </summary>
        public FixedLengthProperty<Nullable<int>> T1_TRMCNTRY { get; private set; }
        /// <summary>
        /// Terminal Currency Code
        /// EMV TAG 5F2Ah
        /// </summary>
        public FixedLengthProperty<Nullable<int>> T1_TRMCURR { get; private set; }
        /// <summary>
        /// Terminal Currency Exponent
        /// EMV TAG 5F36h
        /// </summary>
        public FixedLengthProperty<Nullable<int>> T1_TRMCRREXP { get; private set; }
        /// <summary>
        /// Merchant Identifier
        /// EMV TAG 9F16h
        /// 15 chars long
        /// </summary>
        public FixedLengthProperty<string> T1_MERCHID { get; private set; }
        /// <summary>
        /// Merchant Category Code
        /// EMV TAG 9F15h
        /// 4 chars long
        /// </summary>
        public FixedLengthProperty<string> T1_MCC { get; private set; }
        /// <summary>
        /// Terminal Identification
        /// EMV TAG 9F1Ch
        /// 8 chars long
        /// </summary>
        public FixedLengthProperty<string> T1_TRMID { get; private set; }
        /// <summary>
        /// Terminal Capabilities
        /// EMV TAG 9F33h
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_TRMCAPAB { get; private set; }
        /// <summary>
        /// Additional Terminal Capabilities
        /// EMV TAG 9F40h
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_ADDTRMCP { get; private set; }
        /// <summary>
        /// Terminal Type
        /// EMV TAG 9F35h
        /// </summary>
        public FixedLengthProperty<Nullable<int>> T1_TRMTYP { get; private set; }
        /// <summary>
        /// Terminal Action Code for Default Case
        /// The last TAC checked, if matched the transaction will be denied even if it could have been approved online.
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_TACDEF { get; private set; }
        /// <summary>
        /// Terminal Action Code for offline Denial
        /// The first TAC checked, if matched the transaction will be denied before going online.
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_TACDEN { get; private set; }
        /// <summary>
        /// Terminal Action Code for online processing
        /// The second TAC checked, if matched the transaction may go online to authorize.
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_TACONL { get; private set; }
        /// <summary>
        /// Terminal Floor Limit
        /// Used to determine if the transaction should go online
        /// EMV TAG 9F1Bh
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_FLRLIMIT { get; private set; }
        /// <summary>
        /// Transaction Category Code
        /// EMV TAG 9F53h
        /// </summary>
        public FixedLengthProperty<string> T1_TCC { get; private set; }
        /// <summary>
        /// Supports CTLS if the transaction value is zero?
        /// </summary>
        public TextProperty<Nullable<bool>> T1_CTLSZEROAM { get; private set; }
        /// <summary>
        /// Contactless mode for this AID
        /// </summary>
        public FixedLengthProperty<ContactlessMode> T1_CTLSMODE { get; private set; }
        /// <summary>
        /// Terminal Contactless Transaction Limit
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_CTLSTRNLIM { get; private set; }
        /// <summary>
        /// Terminal Contactless Floor Limit
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_CTLSFLRLIM { get; private set; }
        /// <summary>
        /// Terminal Contactless Cardholder Verification Methods Required Limit
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_CTLSCVMLIM { get; private set; }
        /// <summary>
        /// PayPass Magnetic Stripe Application Version Number
        /// EMV TAG 9F6Dh
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_CTLSAPPVER { get; private set; }
        /// <summary>
        /// Reserved for Future Use
        /// </summary>
        public FixedLengthProperty<Nullable<int>> T1_RUF1 { get; private set; }
        /// <summary>
        /// Default Transaction Certificate Data Object List
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_TDOLDEF { get; private set; }
        /// <summary>
        /// Default Dynamic Data Authentication Data Object List
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_DDOLDEF { get; private set; }
        /// <summary>
        /// Authorization Response Codes for offline transactions
        /// Obsolete and ignored since EMV 4, default is "Y1Z1Y3Z3"
        /// </summary>
        public FixedLengthProperty<string> T1_ARCOFFLN { get; private set; }
        /// <summary>
        /// Contactless Terminal Action Code for Default Case
        /// The last TAC checked, if matched the transaction will be denied even if it could have been approved online.
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_CTLSTACDEF { get; private set; }
        /// <summary>
        /// Contactless Terminal Action Code for offline Denial
        /// The first TAC checked, if matched the transaction will be denied before going online.
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_CTLSTACDEN { get; private set; }
        /// <summary>
        /// Contactless Terminal Action Code for online processing
        /// The second TAC checked, if matched the transaction may go online to authorize.
        /// </summary>
        public FixedLengthProperty<HexadecimalData> T1_CTLSTACONL { get; private set; }

        /// <summary>
        /// Default value for Transaction Category Code.
        /// </summary>
        internal const string DEFAULT_TCC = "R";
		/// <summary>
		/// Terminal capabilities fixed length.
		/// </summary>
		public const int TERMINAL_CAPABILITIES_LENGTH = 6;
		/// <summary>
		/// Additional Terminal Capabilities fixed length.
		/// </summary>
		public const int ADDITIONAL_TERMINAL_CAPABILITIES_LENGTH = 10;
		/// <summary>
		/// Stone application index into the pinpad.
		/// </summary>
		internal const int STONE_ACQUIRER_NUMBER = 8;

		/// <summary>
		/// Constructor
		/// </summary>
		public AidTable()
		{
			this.T1_APPVER1 = new FixedLengthProperty<HexadecimalData>("T1_APPVER1", 4, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_APPVER2 = new FixedLengthProperty<HexadecimalData>("T1_APPVER2", 4, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_APPVER3 = new FixedLengthProperty<HexadecimalData>("T1_APPVER3", 4, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_TRMCNTRY = new FixedLengthProperty<int?>("T1_TRMCNTRY", 3, false, 
                StringFormatter.IntegerStringFormatter, StringParser.IntegerStringParser);
			this.T1_TRMCURR = new FixedLengthProperty<int?>("T1_TRMCURR", 3, false, 
                StringFormatter.IntegerStringFormatter, StringParser.IntegerStringParser);
			this.T1_TRMCRREXP = new FixedLengthProperty<int?>("T1_TRMCRREXP", 1, false, 
                StringFormatter.IntegerStringFormatter, StringParser.IntegerStringParser);
			this.T1_MERCHID = new FixedLengthProperty<string>("T1_MERCHID", 15, false, 
                StringFormatter.StringStringFormatter, StringParser.StringStringParser);
			this.T1_MCC = new FixedLengthProperty<string>("T1_MCC", 4, false, 
                StringFormatter.StringStringFormatter, StringParser.StringStringParser);
			this.T1_TRMID = new FixedLengthProperty<string>("T1_TRMID", 8, false, 
                StringFormatter.StringStringFormatter, StringParser.StringStringParser);
			this.T1_TRMCAPAB = new FixedLengthProperty<HexadecimalData>("T1_TRMCAPAB", 6, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_ADDTRMCP = new FixedLengthProperty<HexadecimalData>("T1_ADDTRMCP", 10, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_TRMTYP = new FixedLengthProperty<int?>("T1_TRMTYP", 2, false, 
                StringFormatter.IntegerStringFormatter, StringParser.IntegerStringParser);
			this.T1_TACDEF = new FixedLengthProperty<HexadecimalData>("T1_TACDEF", 10, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_TACDEN = new FixedLengthProperty<HexadecimalData>("T1_TACDEN", 10, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_TACONL = new FixedLengthProperty<HexadecimalData>("T1_TACONL", 10, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_FLRLIMIT = new FixedLengthProperty<HexadecimalData>("T1_FLRLIMIT", 8, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_TCC = new FixedLengthProperty<string>("T1_TCC", 1, false, 
                StringFormatter.StringStringFormatter, StringParser.StringStringParser);
			this.T1_CTLSZEROAM = new TextProperty<bool?>("T1_CTLSZEROAM", false, 
                StringFormatter.BooleanStringFormatter, StringParser.BooleanStringParser);
			this.T1_CTLSMODE = new FixedLengthProperty<ContactlessMode>("T1_CTLSMODE", 1, false, 
                StringFormatter.EnumStringFormatter<ContactlessMode>, StringParser.EnumStringParser<ContactlessMode>);
			this.T1_CTLSTRNLIM = new FixedLengthProperty<HexadecimalData>("T1_CTLSTRNLIM", 8, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_CTLSFLRLIM = new FixedLengthProperty<HexadecimalData>("T1_CTLSFLRLIM", 8, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_CTLSCVMLIM = new FixedLengthProperty<HexadecimalData>("T1_CTLSCVMLIM", 8, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_CTLSAPPVER = new FixedLengthProperty<HexadecimalData>("T1_CTLSAPPVER", 4, false, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_RUF1 = new FixedLengthProperty<int?>("T1_RUF1", 1, false, 
                StringFormatter.IntegerStringFormatter, StringParser.IntegerStringParser, null, 0);
			this.T1_TDOLDEF = new FixedLengthProperty<HexadecimalData>("T1_TDOLDEF", 40, false, 
                StringFormatter.HexadecimalRightPaddingStringFormatter, StringParser.HexadecimalRightPaddingStringParser);
			this.T1_DDOLDEF = new FixedLengthProperty<HexadecimalData>("T1_DDOLDEF", 40, false, 
                StringFormatter.HexadecimalRightPaddingStringFormatter, StringParser.HexadecimalRightPaddingStringParser);
			this.T1_ARCOFFLN = new FixedLengthProperty<string>("T1_ARCOFFLN", 8, false, 
                StringFormatter.StringStringFormatter, StringParser.StringStringParser, null, "Y1Z1Y3Z3");
			this.T1_CTLSTACDEF = new FixedLengthProperty<HexadecimalData>("T1_CTLSTACDEF", 10, true, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_CTLSTACDEN = new FixedLengthProperty<HexadecimalData>("T1_CTLSTACDEN", 10, true, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);
			this.T1_CTLSTACONL = new FixedLengthProperty<HexadecimalData>("T1_CTLSTACONL", 10, true, 
                StringFormatter.HexadecimalStringFormatter, StringParser.HexadecimalStringParser);

			{//PinPadBaseTableController starts the region and doesn't close
				AddProperty(this.T1_APPVER1);
				AddProperty(this.T1_APPVER2);
				AddProperty(this.T1_APPVER3);
				AddProperty(this.T1_TRMCNTRY);
				AddProperty(this.T1_TRMCURR);
				AddProperty(this.T1_TRMCRREXP);
				AddProperty(this.T1_MERCHID);
				AddProperty(this.T1_MCC);
				AddProperty(this.T1_TRMID);
				AddProperty(this.T1_TRMCAPAB);
				AddProperty(this.T1_ADDTRMCP);
				AddProperty(this.T1_TRMTYP);
				AddProperty(this.T1_TACDEF);
				AddProperty(this.T1_TACDEN);
				AddProperty(this.T1_TACONL);
				AddProperty(this.T1_FLRLIMIT);
				AddProperty(this.T1_TCC);
				AddProperty(this.T1_CTLSZEROAM);
				AddProperty(this.T1_CTLSMODE);
				AddProperty(this.T1_CTLSTRNLIM);
				AddProperty(this.T1_CTLSFLRLIM);
				AddProperty(this.T1_CTLSCVMLIM);
				AddProperty(this.T1_CTLSAPPVER);
				AddProperty(this.T1_RUF1);
				AddProperty(this.T1_TDOLDEF);
				AddProperty(this.T1_DDOLDEF);
				AddProperty(this.T1_ARCOFFLN);
				AddProperty(this.T1_CTLSTACDEF);
				AddProperty(this.T1_CTLSTACDEN);
				AddProperty(this.T1_CTLSTACONL);
			}//PinPadBaseTableController starts the region and doesn't close
			EndLastRegion();
		}
	}
}
