using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReload
{
	int CurrentClipSize{ get; set; }
	void Shoot();
}
