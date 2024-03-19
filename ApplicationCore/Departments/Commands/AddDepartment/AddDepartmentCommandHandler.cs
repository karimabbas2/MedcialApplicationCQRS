using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using ApplicationCore.interfaces;
using ApplicationCore.Interfaces.Invoice;
using ApplicationDomain;
using MediatR;

namespace ApplicationCore.Departments.Commands.AddDepartment
{
    public class AddDepartmentCommandHandler(IDepartmentRepository departmentRepository, IInvoice invoice) : IRequestHandler<AddDepartmentCommand, ServiceResponse>
    {
        private readonly IDepartmentRepository _departmentReposiroty = departmentRepository;
        private readonly IInvoice _invoice = invoice;
        public async Task<ServiceResponse> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Validation
            var validator = new AddDepartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) throw new CustomValidationException(validationResult.Errors);

            Department department = new()
            {
                Id = Guid.NewGuid().ToString(),
                Details = request.Details,
                Name = request.Name,
            };

            if (await _departmentReposiroty.GetAsync(department.Id) is not null) return new ServiceResponse(false, "this Departments is exist");
            await _departmentReposiroty.InsertAsync(department);

            //Write Bytes of Genertited File
            var FileContentResult = _invoice.GenerteInvoice(department);
            byte[] fileContents = FileContentResult.FileContents;
            string desktopFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string filePath = Path.Combine(desktopFolderPath, $"C:\\Users\\20115\\Desktop\\firstPdf\\{department.Name}.pdf");
            File.WriteAllBytes(filePath, fileContents);
            return new ServiceResponse(true, "Department Created Successfully");

        }

    }
}