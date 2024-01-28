public class Word
{
    private string _text;
    private bool _isHidden;

    // Constructors
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Methods
    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string underscoreLines = new string('_', _text.Length);
            return underscoreLines;
        }
        else
        {
            return _text;
        }
    }
}
