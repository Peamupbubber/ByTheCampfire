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



        public void PickColor(BaseEventData data)
        {
            PointerEventData pointer = data as PointerEventData;

            cursor.position = new Vector3(pointer.position.x - 20f, pointer.position.y - 20f);

            Color pickedColor = colorChart.GetPixel((int)(cursor.localPosition.x * (colorChart.width / transform.GetChild(0).GetComponent<RectTransform>().rect.width)), (int)(cursor.localPosition.y * (colorChart.height / transform.GetChild(0).GetComponent<RectTransform>().rect.height)));
            button.color = pickedColor;
            cursorColor.color = pickedColor;
            ColorPickerEvent.Invoke(pickedColor);
        }
    }
}
