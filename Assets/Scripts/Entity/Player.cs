using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    [SerializeField] private PlayerClone[] clones;
    public InputActionAsset input;

    public static int movesCount;
    private void Awake()
    {
        input.FindActionMap("CharacterControls").FindAction("Movement").performed += ctx => ReadInput(ctx, ctx.ReadValue<Vector3>());
    }

    private void Start()
    {
        movesCount = 0;
        targetPos = transform.position;
        Direction = transform.position;
        Actions.AssignEntity(this);
    }

    private void ReadInput(InputAction.CallbackContext ctx, Vector3 direction)
    {
        if (ctx.performed)
        {
            targetPos = transform.position + direction;
            Direction = direction;

            if (Ismoving || !CanMove())
                return;

            Actions.AssignEntity(this);
            MakeMove(targetPos);
            targetPos = transform.position;
            Actions.RemoveEntity(this);
            movesCount++;

            if (clones.Length > 0)
                Actions.MoveClone(direction);

        }
        
    }

    public void FinishLevelAnimation()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOScale(1.2f,0.3f));
        sequence.Append(transform.DOScale(0.1f, 0.2f));

        sequence.OnComplete(() => Destroy(gameObject));
    }

    private void OnEnable()
    {
        input.Enable();
        Actions.CompleteLevel += FinishLevelAnimation;
    }

    private void OnDisable()
    {
        input.Disable();
        Actions.CompleteLevel -= FinishLevelAnimation;
    }
}
