using System;
using Godot;

public partial class Health : Node
{
	[Export] private int _maxHealth = 3;
	[Export] private int _initialHealth = 3;

	private int _currentHealth = 0;

	public int CurrentHealth
	{
		get { return _currentHealth; }
		set
		{
			_currentHealth = Mathf.Clamp(value, 0, _maxHealth);
		}
	}

	public int MaxHealth
	{
		get => _maxHealth;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Reset();
	}

	/// <summary>
	/// Resets health points back to their initial values.
	/// </summary>
	public void Reset()
	{
		CurrentHealth = _initialHealth;
	}

	/// <summary>
	/// Damages the character by <paramref name="amount"/>
	/// </summary>
	/// <param name="amount">The damage dealt to the character. The value can't be negative.</param>
	/// <returns>True, if the damage was succesfully delivered. False otherwise.</returns>
	public bool TakeDamage(int amount)
	{
		if (amount < 0)
		{
			GD.PushError("Negative amount is not allowed when taking damage.");
			return false;
		}

		CurrentHealth -= amount;

		return true;
	}

	/// <summary>
	/// Heals the character by <paramref name="amount"/>
	/// </summary>
	/// <param name="amount">The amount of health added to the character. Negative values are not allowed.</param>
	/// <returns>True, if healing was successful. False otherwise.</returns>
	public bool Heal(int amount)
	{
		if (amount < 0)
		{
			GD.PushError("Negative amount is not allowed when healing.");
			return false;
		}

		CurrentHealth += amount;
		return true;
	}
}
