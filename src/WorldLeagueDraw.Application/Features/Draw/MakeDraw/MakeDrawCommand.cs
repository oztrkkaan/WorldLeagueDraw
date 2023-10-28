using MediatR;
using System.Text.RegularExpressions;
using WorldLeagueDraw.Application.Interfaces;
namespace WorldLeagueDraw.Application.Features.Draw.MakeDraw;
//TODO: her class tanımının kendine ait fiziksel dosyası olmalı.
public record MakeDrawCommand : IRequest<MakeDrawCommandResponse>
{
    public string CreatorFullName { get; init; }
    public int GroupCount { get; init; }
}

public class MakeDrawCommandHandler : IRequestHandler<MakeDrawCommand, MakeDrawCommandResponse>
{
    private readonly IWorldLeagueDrawDbContext _dbContext;

    public MakeDrawCommandHandler(IWorldLeagueDrawDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MakeDrawCommandResponse> Handle(MakeDrawCommand request, CancellationToken cancellationToken)
    {
        var countries = _dbContext.Countries.ToList();
        var groupNames = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };

        var draw = new Domain.Entities.Draw(request.CreatorFullName);
        var groups = groupNames.Select(m => new Domain.Entities.Group(m)).ToList();

        draw.Make(countries, groups);
        _dbContext.Draws.Add(draw);
        await _dbContext.SaveChangesAsync();
       
        //TODO: Mapping tool eklenecek.
        return new MakeDrawCommandResponse
        {
            Groups = draw.Groups.Select(m => new GroupDto
            {
                GroupName = m.GroupName,
                Teams = m.Teams.Select(x => new TeamDto { TeamName = x.Name }).ToList(),

            }).ToList()
        };
    }
}

public record MakeDrawCommandResponse
{
    public List<GroupDto> Groups { get; set; }
}
public record GroupDto
{
    public string GroupName { get; init; }
    public List<TeamDto> Teams { get; init; }
}
public record TeamDto
{
    public string TeamName { get; init; }
}