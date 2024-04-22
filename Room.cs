namespace NarrativeProject
{
    internal abstract class Room
    {

        internal abstract string CreateDescription();
        internal abstract void ReceiveChoice(string choice);
    }
}
