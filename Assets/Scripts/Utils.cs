using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

	public static string GetString(string key, Dictionary<string, object> dataDic)
	{
		if (dataDic == null || dataDic.Count < 1) return null;

		object obj = null;
		dataDic.TryGetValue(key, out obj);

		if (obj != null)
		{
			return Convert.ToString(obj);
		}
		else
		{
			return null;
		}

	}

	public static int GetInt(string key, Dictionary<string, object> dataDic)
	{
		object obj = Utils.GetStringFromDictionary(dataDic, key);
		if (obj != null)
		{
			return Convert.ToInt32(obj);
		}

		return -1;
	}

	public static string GetStringFromDictionary(Dictionary<string, object> dict, string key)
	{
		object result = null;

		dict.TryGetValue(key, out result);

		if (result != null)
		{
			return result.ToString();
		}
		return null;
	}

    public static List<string> GetList(string key, Dictionary<string, object> dataDic)
	{
        if (dataDic == null || dataDic.Count < 1) return null;

        object obj = null;
		dataDic.TryGetValue(key, out obj);

		if (obj != null)
		{
            List<string> stringList = obj as List<string>;
			return stringList;
		}
		else
		{
			return null;
		}
	}

	public static TValue GetValue<TKey, TValue>(
		this Dictionary<TKey, TValue> data, TKey key)
	{
		TValue result;
		if (!data.TryGetValue(key, out result))
		{
			return default(TValue);
		}

		return result;
	}
    public static List<string> SplitAndSaveStrings(string input, char c)
        {
        List<string> s = new List<string>();
        string[] splitString = input.Split(c);
        foreach (string element in splitString)
        {
            s.Add(element);
        }
        return s;
        }
    
}
