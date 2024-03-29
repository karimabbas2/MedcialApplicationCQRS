using ApplicationCore.Departments.Commands.UpdateDepartment;
using ApplicationCore.Departments.Commands.Validations;
using ApplicationCore.Departments.Queries.DeleteDepartment;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using ApplicationCore.interfaces;
using ApplicationCore.Interfaces.Invoice;
using ApplicationDomain;
using MediatR;

namespace ApplicationCore.Departments.Commands.AddDepartment
{
    public class DepartmentCommandHandler(IDepartmentRepository departmentRepository, IInvoice invoice)
    : IRequestHandler<AddDepartmentCommand, ResponseResult<string>>,
    IRequestHandler<UpdateDepartmentCommand, ResponseResult<string>>,
    IRequestHandler<DeleteDepartmentCommand, ResponseResult<string>>
    {
        private readonly IDepartmentRepository _departmentReposiroty = departmentRepository;
        private readonly IInvoice _invoice = invoice;

        //Create Command
        public async Task<ResponseResult<string>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Validation
            var validator = new AddDepartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) throw new CustomValidationException(validationResult.Errors);

            Department department = new()
            {
                Details = request.Details,
                Name = request.Name,
            };

            if (await _departmentReposiroty.GetAsync(department.Id) is not null)
                return ResponseHandler.Conflicted<string>("this Departments is exist");

            await _departmentReposiroty.InsertAsync(department);

            //Write Bytes of Genertited File
            var FileContentResult = _invoice.GenerteInvoice(department);
            byte[] fileContents = FileContentResult.FileContents;
            string desktopFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string filePath = Path.Combine(desktopFolderPath, $"C:\\Users\\20115\\Desktop\\firstPdf\\{department.Name}.pdf");
            File.WriteAllBytes(filePath, fileContents);

            return ResponseHandler.Created<string>("Department Created Successfully");

        }

        //Update Command
        public async Task<ResponseResult<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Validation
            var validator = new UpdateDepartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) throw new CustomValidationException(validationResult.Errors);

            var dept = await _departmentReposiroty.GetAsync(request.Id);
            if (dept is null) return ResponseHandler.NotFound<string>("this Departments dose not exist");

            dept.Name = request.Name;
            dept.Details = request.Details;
            await _departmentReposiroty.UpdateAsync(request.Id, dept);
            return ResponseHandler.Success("Department Updated Successfully");
        }

        //Delete Command
        public async Task<ResponseResult<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (await _departmentReposiroty.GetAsync(request.Id) is null) return ResponseHandler.NotFound<string>("No Department with this Id");
            await _departmentReposiroty.DeleteAsync(request.Id);
            return ResponseHandler.Success("Department Deleted Successfully");
        }

    }
}