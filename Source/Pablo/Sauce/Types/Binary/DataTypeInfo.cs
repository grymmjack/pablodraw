using System;
using Eto.Forms;
using System.Collections.Generic;

namespace Pablo.Sauce.Types.Binary
{
	public class DataTypeInfo : BaseText.DataTypeInfo
	{
		public override bool HasFileType { get { return false; } }

		public override bool HasFontName { get { return true; } }

		public override bool HasICEColors { get { return true; } }

		public override bool HasAspectRatio { get { return true; } }

		public override bool HasLetterSpacing { get { return true; } }

		public int Width
		{
			get { return Sauce.ByteFileType * 2; }
			set
			{
				if (value % 2 != 0)
					throw new Exception("width must be divisible by 2");
				if (value < 0 || value > 510)
					throw new Exception("width must be between 0 and 512");
				Sauce.ByteFileType = (byte)(value / 2);
			}
		}

		public override Control GenerateUI()
		{
			return new Admin<DataTypeInfo>(this);
		}
	}
}
