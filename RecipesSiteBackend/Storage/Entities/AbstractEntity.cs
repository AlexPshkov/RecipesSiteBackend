using System.Text;

namespace RecipesSiteBackend.Storage.Entities;

public class AbstractEntity
{

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach ( var fieldInfo in GetType().GetFields() ) 
            stringBuilder.Append( fieldInfo.Name ).Append( ": " ).Append( fieldInfo.GetValue( this ) ).Append( "   " );
        return stringBuilder.ToString();
    }
}