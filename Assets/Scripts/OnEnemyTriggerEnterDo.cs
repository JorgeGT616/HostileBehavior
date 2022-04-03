using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnemyTriggerEnterDo : MonoBehaviour {
    [SerializeField] private UnityEvent alwaysActions;
    [SerializeField] private UnityEvent unignoredActions;
    [SerializeField] List<string> tagsToIgnore;

    private void OnTriggerEnter2D(Collider2D collision) {
        alwaysActions.Invoke();
        foreach(var ignoreTag in tagsToIgnore) {
            if (collision.tag == ignoreTag) {
                return;
            }
        }
    }
}
