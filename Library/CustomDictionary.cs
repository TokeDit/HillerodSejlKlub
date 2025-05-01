using System;

public class CustomDictionary<TKey, TValue>
{
    private List<KeyValuePair<TKey, TValue>> m_list = new List<KeyValuePair<TKey, TValue>>();
    public CustomDictionary()
    {
        
    }

    // Add key value pair
    public void Add(TKey key, TValue value)
    {
        m_list.Add(new KeyValuePair<TKey, TValue>(key, value));
    }

    // Removes the first occurrence of the key value pair
    public void Remove(TKey key, TValue value)
    {
        m_list.Remove(new KeyValuePair<TKey, TValue>(key, value));
    }

    public TKey GetKeyAt(int index)
    {
        return m_list.ElementAt(index).Key;
    }

    public TValue GetValueAt(int index)
    {
        return m_list.ElementAt(index).Value;
    }

    public List<KeyValuePair<TKey, TValue>> GetList()
    {
        return m_list;
    }
}