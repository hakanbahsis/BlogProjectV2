using Entity.DTOs.Images;
using Entity.Enums;
using Microsoft.AspNetCore.Http;

namespace Business.Helpers.Images;
public interface IImageHelper
{
    Task<ImageUploadedDto> UploadImageAsync(string name,IFormFile imageFile,ImageType imageType,string folderName=null);
    void DeleteImage(string imageName);
}
