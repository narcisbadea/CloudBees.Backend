using AutoMapper;
using CloudBees.BLL.DTOs;
using CloudBees.BLL.Services.Interfaces;
using CloudBees.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.BLL.Services.Implementation;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IAuthService authService, IMapper mapper)
    {
        _userRepository = userRepository;
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<UserProfileDTO> GetLoggedUserProfile()
    {
        var loggedUser = await _authService.GetLoggedUser();
        return _mapper.Map<UserProfileDTO>(loggedUser);
    }

    public async Task<List<string>> GetUserRoles(string email)
    {
        var result = await _userRepository.GetUserRoles(email);
        return result;
    }
}
