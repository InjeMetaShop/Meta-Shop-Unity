using UnityEngine.UI;

public class SimpleDemoButtonView : BaseButtonView {

	public Text text;

	public override void SetData(BaseButtonData dataOrigin){
		SimpleDemoButtonData data = dataOrigin as SimpleDemoButtonData;
		text.text = data.Content;
	}
}
