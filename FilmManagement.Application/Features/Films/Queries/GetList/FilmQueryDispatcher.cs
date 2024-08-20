using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using MediatR;


namespace FilmManagement.Application.Features.Films.Queries.GetList
{
    public class FilmQueryDispatcher : IRequestHandler<GetListFilmQueryRequest, ApiPagedResponse<GetListFilmResponseDto>>
    {
        private readonly GetListFilmQueryHandler _getListHandler;
        private readonly GetDynamicListFilmQueryHandler _dynamicHandler;

        public FilmQueryDispatcher(GetListFilmQueryHandler getListHandler, GetDynamicListFilmQueryHandler dynamicHandler)
        {
            _getListHandler = getListHandler;
            _dynamicHandler = dynamicHandler;
        }

        public Task<ApiPagedResponse<GetListFilmResponseDto>> Handle(GetListFilmQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.DynamicQuery != null)
            {
                return _dynamicHandler.Handle(request, cancellationToken);
            }
            else
            {
                return _getListHandler.Handle(request, cancellationToken);
            }
        }
    }

}
