using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InfoGamerHubAssets {

    public class ColorPickButton : MonoBehaviour
    {
        public UnityEvent<Color> ColorPickerEvent;

        [SerializeField] Texture2D colorChart;
        [SerializeField] GameObject chart;

        [SerializeField] RectTransform cursor;
        [SerializeField] Image button;
        [SerializeField] Image cursorColor;

        [SerializeField] private float colorChartXPosEdge;
        [SerializeField] private float colorChartXNegEdge;
        [SerializeField] private float colorChartYPosEdge;
        [SerializeField] private float colorChartYNegEdge;

        /*
        private void Start()
        {
            float width = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
            float height = transform.GetChild(0).GetComponent<RectTransform>().rect.height;

            colorChartXPosEdge = transform.position.x + chart.transform.position.x + (width / 2) - 4 * cursor.rect.width;
            Debug.Log(colorChartXPosEdge);

            colorChartXNegEdge = transform.position.x - width;

            colorChartYPosEdge = transform.position.y + height - 2 * cursor.rect.height;

            colorChartYNegEdge = transform.position.y - height;
        }
        */

        public void PickColor(BaseEventData data)
        {
            PointerEventData pointer = data as PointerEventData;

            float newCursorXPos = pointer.position.x - 20f;
            newCursorXPos = newCursorXPos < colorChartXNegEdge ? colorChartXNegEdge : (newCursorXPos > colorChartXPosEdge ? colorChartXPosEdge : newCursorXPos);

            float newCursorYPos = pointer.position.y - 20f;
            newCursorYPos = newCursorYPos < colorChartYNegEdge ? colorChartYNegEdge : (newCursorYPos > colorChartYPosEdge ? colorChartYPosEdge : newCursorYPos);

            cursor.position = new Vector3(newCursorXPos, newCursorYPos);

            Color pickedColor = colorChart.GetPixel((int)(cursor.localPosition.x * (colorChart.width / transform.GetChild(0).GetComponent<RectTransform>().rect.width)), (int)(cursor.localPosition.y * (colorChart.height / transform.GetChild(0).GetComponent<RectTransform>().rect.height)));
            button.color = pickedColor;
            cursorColor.color = pickedColor;
            ColorPickerEvent.Invoke(pickedColor);
        }
    }
}
