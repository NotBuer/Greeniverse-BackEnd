namespace Greeniverse.src.services.implementations
{
    public void CreateUserNoDuplicate(NewUserDTO dto)
    {
        var user = _repository.GetUserByEmail(dto.Email);
        if (user != null) throw new Exception("Este email já está sendo utilizado");
        dto.Password = CodifyPassword(dto.Password);
        _repository.NewUser(dto);
    }
}
