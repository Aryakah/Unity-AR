//=============================================================================================================================
//
// Copyright (c) 2015-2017 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
// EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
// and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//=============================================================================================================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityStandardAssets.ImageEffects;
namespace EasyAR

{
    public class ImageTargetBehaviour : ImageTargetBaseBehaviour
    {	[SerializeField] GameObject TourImage;
		public bool lowCount=false;
			public int panelNum=0;
		public int imgCount=0;
		//public PostProcessingProfile ppProfile;
		//public 	UnityEngine.PostProcessing.DepthOfFieldModel.Settings dofSetting;	
		private GameObject GM;
		private GameObject homeButtom;

		private bool prePattern=false;
		public float num360=0;
		private GameObject imagePanel;
		[SerializeField] GameObject headPanel;
		[SerializeField] GameObject CC;

		[SerializeField] GameObject renderCamera;
		[SerializeField] GameObject TourObj;
		private float timeZeroOne=0f;

		public int imageId=-1;
		
		private GameObject[] allPanels;

		protected override void Awake()
		{	




			base.Awake();
			TargetFound += OnTargetFound;
			TargetLost += OnTargetLost;
            TargetLoad += OnTargetLoad;
			TargetUnload += OnTargetUnload;

				//GameObject tourImg = GameObject.FindGameObjectWithTag ("TourImage");
				//tourImg.GetComponent<CanvasGroup>().alpha=0;

			GameObject	mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");	
			
			mainCamera.GetComponent<BlurOptimized>().enabled=false;
			GameObject[] grayBackLor = GameObject.FindGameObjectsWithTag ("backTag");	
			foreach (GameObject item in grayBackLor)
			{
				item.GetComponent<RawImage>().color=new Color32(255,255,255,0);
			}
			



			//ppProfile.depthOfField.enabled=false;


		}
        	void OnTargetFound(TargetAbstractBehaviour behaviour)

		{			
			
			
			
					if(panelNum==7)
					TourImage.GetComponent<CanvasGroup>().alpha=1;
					else
					TourImage.GetComponent<CanvasGroup>().alpha=0;
					homeButtom = GameObject.FindGameObjectWithTag ("homeButton");	

			GameObject	mainImage = GameObject.FindGameObjectWithTag ("mainImage");	
			
			InvokeRepeating("patternReset",0,0.2f);

			if(Target.Id != imageId && headPanel.transform.GetChild(0).gameObject.GetComponent<CanvasGroup>().alpha<=0 )
			{


				headPanel.transform.GetChild(0).gameObject.transform.GetChild(8).gameObject.GetComponent<CanvasGroup>().alpha=0;

				GameObject tourImg = GameObject.FindGameObjectWithTag ("TourImage");
				
				tourImg.GetComponent<CanvasGroup>().alpha=1;
				
				
					if(panelNum!=7){
					tourImg.GetComponent<CanvasGroup>().alpha=0;
					Debug.Log("tourImg.GetComponent<CanvasGroup>().alpha"+tourImg.GetComponent<CanvasGroup>().alpha);
				}

				

				prePattern=false;

				//  && homeButtom.GetComponent<imageChanger>().patternIdreset=="reset"

				homeButtom.GetComponent<imageChanger>().patternIdreset="onreset";
				homeButtom.GetComponent<imageChanger>().resetScalPosition();
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<image_rotator>().infoCounter=1;
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<image_rotator>().resetAlpha();
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RawImage>().texture=
				Resources.Load<Texture2D>(panelNum.ToString()+"_"+(1));
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RawImage>().SetNativeSize();
				
				//headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild();
				//headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(panelNum-1);
				//int countChild=headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.childCount;
				

				/* 
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text=
				Fa.faConvert(headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(panelNum-1).gameObject.GetComponent<Text>().text);
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().fontSize=
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(panelNum-1).gameObject.GetComponent<Text>().fontSize;
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().lineSpacing=
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(panelNum-1).gameObject.GetComponent<Text>().lineSpacing;			
					/* 

				
				for(int i=imgCount;i<25;i++){
				headPanel.transform.GetChild(2).gameObject.transform.GetChild(i).gameObject.GetComponent<RawImage>().color=new Color32(255,255,255,0);
			}

			*/



				headPanel.GetComponent<Funks>().panelNumF=panelNum;
				headPanel.GetComponent<Funks>().num360F=num360;



				headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RawImage>().texture=
				Resources.Load<Texture2D>("t"+panelNum.ToString());

			for(int i=0;i<100;i++){
			headPanel.transform.GetChild(2).gameObject.transform.GetChild(i).gameObject.GetComponent<RawImage>().color=new Color32(255,255,255,255);
			headPanel.transform.GetChild(2).gameObject.transform.GetChild(i).gameObject.SetActive(true);
			headPanel.transform.GetChild(2).gameObject.transform.GetChild(i).gameObject.GetComponent<RawImage>().texture=
			Resources.Load<Texture2D>(panelNum.ToString()+"_"+((i%imgCount)+1));

			}

			if(lowCount)
			{
			for (int i=imgCount;i<25;i++){
				
				headPanel.transform.GetChild(2).gameObject.transform.GetChild(i).gameObject.GetComponent<RawImage>().color=new Color32(255,255,255,0);
			}
			}
		
			
			timeZeroOne=0f;		

			
			Invoke("invokeBloomParent",0.5f);
			Invoke("RealityDeactive",1f);
			

			//GM.GetComponent<imageChanger>().ChangeBloomAtRuntime();

			
			//imagePanel = GameObject.FindGameObjectWithTag ("ImagePanel");		
			//imagePanel.transform.GetChild(0).gameObject.SetActive(true);
			
			

			

			InvokeRepeating("LoadHeadPanel",1f,0.01f);
		
            Debug.Log("Found: " + Target.Id);

			imageId=Target.Id;
		}
		
        }

	void OnTargetLost(TargetAbstractBehaviour behaviour)
		{	
			CancelInvoke("patternReset");
			imageId=-2;
 Debug.Log("Lost: " + Target.Id);
        }

		void OnTargetLoad(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
		{	
			Debug.Log("Load target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
		}
		void OnTargetUnload(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
		{
			Debug.Log("Unload target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);



		}

		
		public void LoadHeadPanel(){
			
			headPanel.transform.GetChild(2).gameObject.GetComponent<CanvasGroup>().alpha=timeZeroOne;
			headPanel.transform.GetChild(0).gameObject.GetComponent<CanvasGroup>().alpha=timeZeroOne-0.8f;
			//headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<CanvasGroup>().alpha=timeZeroOne-1.3f;

			
			
			if(timeZeroOne>2.3){

				CancelInvoke("LoadHeadPanel");
			}
			//Debug.Log(timeZeroOne);

			timeZeroOne+=Time.deltaTime;

		}
		
			public void invokeBloomParent(){
				GM = GameObject.FindGameObjectWithTag ("GM");	
				GM.GetComponent<imageChanger>().ChangeBloomAtRuntime();
		
	}


	public void RealityDeactive(){

		//renderCamera.SetActive(false);

	}

	public void patternReset(){

			
	
			
			Debug.Log(imageId);

			if(Target.Id != imageId && headPanel.transform.GetChild(0).gameObject.GetComponent<CanvasGroup>().alpha<=0 ){
			homeButtom = GameObject.FindGameObjectWithTag ("homeButton");	

			GameObject	mainImage = GameObject.FindGameObjectWithTag ("mainImage");	
				//  && homeButtom.GetComponent<imageChanger>().patternIdreset=="reset"

				GameObject tourImg = GameObject.FindGameObjectWithTag ("TourImage");
				tourImg.GetComponent<CanvasGroup>().alpha=1;
				
				if(panelNum!=7){
					tourImg.GetComponent<CanvasGroup>().alpha=0;
					Debug.Log("tourImg.GetComponent<CanvasGroup>().alpha"+tourImg.GetComponent<CanvasGroup>().alpha);
				}


				homeButtom.GetComponent<imageChanger>().patternIdreset="onreset";
				homeButtom.GetComponent<imageChanger>().resetScalPosition();
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<image_rotator>().infoCounter=1;
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<image_rotator>().resetAlpha();
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RawImage>().texture=
				Resources.Load<Texture2D>(panelNum.ToString()+"_"+(1));
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<RawImage>().SetNativeSize();
				
				//headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild();
				//headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(panelNum-1);
				//int countChild=headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.childCount;
				

				/* 
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text=
				Fa.faConvert(headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(panelNum-1).gameObject.GetComponent<Text>().text);
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().fontSize=
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(panelNum-1).gameObject.GetComponent<Text>().fontSize;
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().lineSpacing=
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(panelNum-1).gameObject.GetComponent<Text>().lineSpacing;			
					/* 

				
				for(int i=imgCount;i<25;i++){
				headPanel.transform.GetChild(2).gameObject.transform.GetChild(i).gameObject.GetComponent<RawImage>().color=new Color32(255,255,255,0);
			}

			*/
				headPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<RawImage>().texture=
				Resources.Load<Texture2D>("t"+panelNum.ToString());

				headPanel.GetComponent<Funks>().panelNumF=panelNum;
				headPanel.GetComponent<Funks>().num360F=num360;




			for(int i=0;i<100;i++){
			headPanel.transform.GetChild(2).gameObject.transform.GetChild(i).gameObject.GetComponent<RawImage>().color=new Color32(255,255,255,255);
			headPanel.transform.GetChild(2).gameObject.transform.GetChild(i).gameObject.SetActive(true);
			headPanel.transform.GetChild(2).gameObject.transform.GetChild(i).gameObject.GetComponent<RawImage>().texture=
			Resources.Load<Texture2D>(panelNum.ToString()+"_"+((i%imgCount)+1));

			}

			if(lowCount)
			{
			for (int i=imgCount;i<25;i++){
				
				headPanel.transform.GetChild(2).gameObject.transform.GetChild(i).gameObject.GetComponent<RawImage>().color=new Color32(255,255,255,0);
			}
			}
		
			
			timeZeroOne=0f;		

			
			Invoke("invokeBloomParent",0.5f);
			Invoke("RealityDeactive",1f);
			

			//GM.GetComponent<imageChanger>().ChangeBloomAtRuntime();

			
			//imagePanel = GameObject.FindGameObjectWithTag ("ImagePanel");		
			//imagePanel.transform.GetChild(0).gameObject.SetActive(true);
			
			

			

			InvokeRepeating("LoadHeadPanel",1f,0.01f);

			
		
            Debug.Log("Found: " + Target.Id);

			imageId=Target.Id;
			CancelInvoke("patternReset");
		}
	}


    }



}
