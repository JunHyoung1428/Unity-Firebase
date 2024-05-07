
using System;


//직렬화 가능한것만 Json 으로 만들 수 있음 
[Serializable]
public class UserData
{
    public string nickName;
    public int level;
    public CharacterType type;

    public UserData() { this.nickName = "nickName"; this.level = 1; type = CharacterType.Warrior; }

    public UserData( string nickName, int level, CharacterType type )
    {
        this.nickName = nickName;
        this.level = level;
        this.type = type;
    }
}


public enum CharacterType
{
    Warrior,
    Wizard,
    Rogue,
}