using UnityEngine;
using System.Collections;

[System.Serializable]
public class Shape {
	public bool[] blocks;
	/// <summary>
	/// Need dimensions because single array does not have width etc length
	/// </summary>
	public int width;
	public int depth;
	public int height;

	public override bool Equals(System.Object obj)
	{
		if (obj == null) { return false; }

		Shape other = obj as Shape;

		bool isEqual = (this.blocks.Length == other.blocks.Length)
			&& this.width == other.width && this.depth == other.depth
			&& this.height == other.height;

		if (isEqual)
		{
			for (int i = 0; i < this.blocks.Length; i++)
			{
				isEqual = this.blocks[i] == other.blocks[i];

				if (!isEqual)
				{
					return false;
				}
			}
		}

		return isEqual;
	}
}
