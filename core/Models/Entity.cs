namespace core.Models;

/// <summary>
/// Entity
/// </summary>
public class Entity
{
	/// <summary>
	/// ctor
	/// </summary>
	/// <param name="id">Entity Id</param>
	/// <param name="name">Entity Name</param>
	/// <param name="displayName">Display Name</param>
	/// <param name="isActive">Is Active</param>
    public Entity(Guid id,
		string name,
		string displayName,
		bool isActive)
	{
		Id = id;
		Name = name;
		DisplayName = displayName;
		IsActive = isActive;
	}

	/// <summary>
	/// Id
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Name
	/// </summary>
	public string Name { get; set; } = null!;

	/// <summary>
	/// Display Name
	/// </summary>
	public string DisplayName { get; set; } = null!;

	/// <summary>
	/// IsActive
	/// </summary>
	public bool IsActive { get; set; } = true;
}