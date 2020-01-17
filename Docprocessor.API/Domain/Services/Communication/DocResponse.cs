using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docprocessor.API.Domain.Models;

namespace Docprocessor.API.Domain.Services.Communication
{
    public class DocResponse : BaseResponse<Doc>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="doc">Saved doc.</param>
        /// <returns>Response.</returns>
        public DocResponse(Doc doc) : base(doc)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public DocResponse(string message) : base(message)
        { }
    }
}
