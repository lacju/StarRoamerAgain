﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class TooltipProperties
{
	public string
		text;
	
	public Font
		font;
	
	public FontStyle
		fontStyle;
	
	public Color
		color = Color.white;
    public int
        line;

    public TooltipProperties (string _text, Font _font, FontStyle _fontStyle, Color _color, int _line)
	{
		text = _text;
		font = _font;
		fontStyle = _fontStyle;
		color = _color;
        line = _line;
    }
}