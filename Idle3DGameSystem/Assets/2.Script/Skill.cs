/// <summary>
/// 스킬 클래스용 인터페이스
/// </summary>
interface Skills
{
    /// <summary>
    /// 스킬명 세팅용
    /// </summary>
    /// <param name="setName"></param>
    /// <returns></returns>
    string SetName(string setName);
    /// <summary>
    /// 스킬로직 세팅용
    /// </summary>
    void SkillLogic();
    /// <summary>
    /// 소모Mp세팅용
    /// </summary>
    /// <param name="setMp"></param>
    /// <returns></returns>
    int SetMp(int setMp);
}
/// <summary>
/// 스킬 클래스 구현
/// </summary>
class Skill : Skills //인터페이스는 뭐하는 거길래 퍼블릭이어야 하지?
{
    /// <summary>
    /// 스킬명
    /// </summary>
    string skillName;
    /// <summary>
    /// 소모MP
    /// </summary>
    int usedMp;
    /// <summary>
    /// 스킬명 세팅용
    /// </summary>
    /// <param name="setName"></param>
    /// <returns></returns>
    public string SetName(string setName)
    { return skillName = setName; }
    /// <summary>
    /// 스킬로직 세팅용
    /// </summary>
    public void SkillLogic() { }
    /// <summary>
    /// 소모Mp세팅용
    /// </summary>
    /// <param name="setMp"></param>
    /// <returns></returns>
    public int SetMp(int setMp)
    { return usedMp = setMp; }
}