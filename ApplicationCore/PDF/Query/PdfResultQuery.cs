using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using MediatR;

namespace ApplicationCore.PDF.Query
{
    public class PdfResultQuery : IRequest<ResponseResult<string>>
    {

    }
}