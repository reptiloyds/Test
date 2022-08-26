using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
// ReSharper disable InconsistentNaming

namespace UI.Base
{
	[ExecuteInEditMode]
	public class BaseButton : MonoBehaviour
	{
		[SerializeField] protected Button _button;

		[Header("ViewSettings")]
		[SerializeField] protected Image _image;
		[SerializeField] protected Image _back;
		
		[SerializeField] protected TextMeshProUGUI[] _texts;
		
		private Color _interactableColor;
		private Color _unInteractableColor;

		private float _downTime;
		
		private BaseButton _currentOverlapped;

		private Action _callback;
		private bool Interactable => _button.interactable;

		[Inject]
		private void Construct()
		{
			if (_image != null)
			{
				_interactableColor = _image.color;	
			}

			if (_back != null)
			{
				_unInteractableColor = _back.color;	
			}
		}

		protected void Awake()
		{
			if (_image == null) _image = GetComponent<Image>();
			if (_button == null) _button = GetComponentInChildren<Button>();
			_texts = GetComponentsInChildren<TextMeshProUGUI>();
		}

		protected void OnEnable()
		{
			if (_button == null) _button = GetComponent<Button>();
			if (_button == null) return;
			_button.onClick.RemoveAllListeners();
			_button.onClick.AddListener(OnClick);
		}

		public void SetText(string text)
		{
			if (_texts.Length < 1) return;
			_texts[0].text = text;
		}
		
		public void SetText(int element, string text)
		{
			if (_texts.Length < element) return;
			_texts[element].text = text;
		}
		
		public BaseButton SetCallback(Action callback)
		{
			_callback = callback;
			return this;
		}

		public void SetInteractable(bool interactable)
		{
			_button.interactable = interactable;
			if (interactable)
			{
				_image.color = _interactableColor;
			}
			else
			{
				_image.color = _unInteractableColor;
			}
		}

		private void OnClick()
		{
			if (!Interactable) return;

			_callback?.Invoke();
		}
		
		public void SimulateClick()
		{
			OnClick();
		}
	}
}
