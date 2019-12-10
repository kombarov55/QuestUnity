using UnityEngine;

/**
 * Этот класс оркестритует всеми контроллерами. Упраавляет переключением сцен
 */
namespace DefaultNamespace
{
    public class QuestSceneFlow : MonoBehaviour
    {
        public QuestSceneController questSceneController;
        public QuestScenePresenter QuestScenePresenter;

        /**
         * При старте показываем обычную сцену
         */
        public void Start()
        { 
            QuestScenePresenter.setChoiceHandler(choiceNum => questSceneController.handleTransition(choiceNum));            
            questSceneController.display();
        }
    }
}