namespace eStoreAPI.Controllers;

using BusinessObject;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MemberAPI : ControllerBase
{
    
    private MemberRepository _memberRepository = new MemberRepository();
    
    [HttpGet]
    public ActionResult<IEnumerable<Member>> GetMembers()
    {
        return this._memberRepository.GetAllMembers();
    }
    
    [HttpPut]
    public ActionResult<Member> UpdateMember(Member member)
    {
        var mem = this._memberRepository.GetMemberById(member.MemberId);
        if (mem == null)
        {
            return NotFound();
        }
        this._memberRepository.UpdateMember(member);
        return NoContent();
    }
    
    [HttpPost]
    public ActionResult<Member> AddMember(Member member)
    {
        var mem = this._memberRepository.GetMemberById(member.MemberId);
        if (mem != null)
        {
            return Conflict();
        }
        this._memberRepository.AddMember(member);
        return this.NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult<Member> DeleteMember(int id)
    {
        var mem = this._memberRepository.GetMemberById(id);
        if (mem == null)
        {
            return NotFound();
        }
        this._memberRepository.DeleteMember(mem);
        return NoContent();
    }
}