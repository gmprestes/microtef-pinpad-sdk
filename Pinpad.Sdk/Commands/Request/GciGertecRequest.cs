﻿using System;
using Pinpad.Sdk.Model;
using Pinpad.Sdk.PinpadProperties.Refactor.Property;
using Pinpad.Sdk.PinpadProperties.Refactor.Formatter;
using Pinpad.Sdk.PinpadProperties.Refactor.Parser;
using Pinpad.Sdk.PinpadProperties.Refactor.Command;

namespace Pinpad.Sdk.Commands
{
	internal sealed class GciGertecRequest : BaseCommand
	{
		public override string CommandName { get { return "EX07"; } }
		public FixedLengthProperty<KeyboardNumberFormat> NumericInputType { get; set; }
		public FixedLengthProperty<KeyboardTextFormat> TextInputType { get; set; }
		public FixedLengthProperty<FirstLineLabelCode> LabelFirstLine { get; set; }
		public FixedLengthProperty<SecondLineLabelCode> LabelSecondLine { get; set; }
		public FixedLengthProperty<Nullable<int>> MaximumCharacterLength { get; set; }
		public FixedLengthProperty<Nullable<int>> MinimumCharacterLength { get; set; }
		public FixedLengthProperty<Nullable<int>> TimeOut { get; set; }
		public FixedLengthProperty<Nullable<int>> TimeIdle { get; set; }

		public GciGertecRequest ()
			: base(new GertecContext())
		{
			this.NumericInputType = new FixedLengthProperty<KeyboardNumberFormat>("NumericInputType", 1, false, 
                StringFormatter.EnumStringFormatter<KeyboardNumberFormat>, 
                StringParser.EnumStringParser<KeyboardNumberFormat>);
			this.TextInputType = new FixedLengthProperty<KeyboardTextFormat>("TextInputType", 1, false, 
                StringFormatter.EnumStringFormatter<KeyboardTextFormat>, 
                StringParser.EnumStringParser<KeyboardTextFormat>);
			this.LabelFirstLine = new FixedLengthProperty<FirstLineLabelCode>("LabelFirstLine", 2, false, 
                StringFormatter.EnumStringFormatter<FirstLineLabelCode>, 
                StringParser.EnumStringParser<FirstLineLabelCode>);
			this.LabelSecondLine = new FixedLengthProperty<SecondLineLabelCode>("LabelSecondLine", 2, false, 
                StringFormatter.EnumStringFormatter<SecondLineLabelCode>, 
                StringParser.EnumStringParser<SecondLineLabelCode>);
			this.MaximumCharacterLength = new FixedLengthProperty<Nullable<int>>("MaximumCharacterLength", 2, 
                false, StringFormatter.IntegerStringFormatter, StringParser.IntegerStringParser);
			this.MinimumCharacterLength = new FixedLengthProperty<Nullable<int>>("MinimumCharacterLength", 2, 
                false, StringFormatter.IntegerStringFormatter, StringParser.IntegerStringParser);
			this.TimeOut = new FixedLengthProperty<Nullable<int>>("TimeOut", 3, false, 
                StringFormatter.IntegerStringFormatter, StringParser.IntegerStringParser);
			this.TimeIdle = new FixedLengthProperty<Nullable<int>>("TimeIdle", 3, false, 
                StringFormatter.IntegerStringFormatter, StringParser.IntegerStringParser);
			
			{
				this.AddProperty(this.NumericInputType);
				this.AddProperty(this.TextInputType);
				this.AddProperty(this.LabelFirstLine);
				this.AddProperty(this.LabelSecondLine);
				this.AddProperty(this.MaximumCharacterLength);
				this.AddProperty(this.MinimumCharacterLength);
				this.AddProperty(this.TimeOut);
				this.AddProperty(this.TimeIdle);
			}
		}

		public static bool IsSupported (string manufacturerName, string model, string manufacturerVersion)
		{
			int v1, v2, v3;

			if (manufacturerName.Contains("GERTEC") == false) { return false; }

			if (model.Contains("MOBI PIN 10") == true)
			{
				string [] v = manufacturerVersion.Trim().Split('.', ' ');

				if (v.Length != 3) { return false; }

				if (Int32.TryParse(v [0], out v1) == true && Int32.TryParse(v [1], out v2) == true && Int32.TryParse(v [2], out v3) == true)
				{
					if (v1 < 1 && v2 < 11 && v3 < 160324) { return false; }
				}
				else { return false; }
			}
			else { return false; }

			return true;
		}
	}
}
