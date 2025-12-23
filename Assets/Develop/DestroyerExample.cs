using UnityEngine;

public class DestroyerExample : MonoBehaviour
{
    [SerializeField] private float _enemyLifeTime = 5f;
    [SerializeField] private DestroyerView _viewPrefab;
    [SerializeField] private Entity _entityPrefab;
    [SerializeField] private Canvas _canvas;

    private Destroyer _destroyer;
    private DestroyerView _view;

    private void Awake()
    {
        _destroyer = new Destroyer();

        _view = Instantiate(_viewPrefab, _canvas.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Entity enemy = Instantiate(_entityPrefab, _view.transform);

            _destroyer.RegisterEnemy(enemy, () => enemy.IsDead);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Entity enemy = Instantiate(_entityPrefab, _view.transform);

            float deathTime = Time.time + _enemyLifeTime;

            _destroyer.RegisterEnemy(enemy, () => Time.time >= deathTime);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Entity enemy = Instantiate(_entityPrefab, _view.transform);

            _destroyer.RegisterEnemy(enemy, () => _destroyer.CurrentCount > 5);
        }

        _destroyer.Update();
    }
}
