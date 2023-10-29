/*
  * - Name: MatchShape.class
  * - Writer: Hee-su Yoo, Byeong-kwon Lee
  * - Content: Hansel and Gretel Epi3 Minigame - A script that checks whether each object is in the correct position and returns it to its original position if it is incorrect.
  * 1) If the answer is correct, make a sound
  *
  * - HISTORY
  * 2021-08-11: Initial development
  * 2021-08-17: Code standardization and comment processing
  * 2021-08-26: Make a sound when the answer is correct (Byung-kwon Lee)
  *
  * <Variable>
  * mgo_GameControl "AnswerCheckEpi3" Variable for script connection
  * mv3_initPos; Variable for storing current location
  *
  * <Function>
  *
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchShape : MonoBehaviour{
    Vector3 mv3_initPos;                                                                                               //현재 위치 저장을 위한 변수                                                                                                 
    private GameObject mgo_GameControl;                                                                                //AnswerCheckEpi2 스크립트 연결을 위한 변수

    GameObject mg_SoundManager;
    
    void Start(){
        mv3_initPos = this.transform.position;                                                                         //현재 위치 저장 
        mgo_GameControl = GameObject.Find("GameControl");                                                              //오브젝트 연결     
        mg_SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결
    }

    void Update(){
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv3_initPos, 11f * Time.deltaTime);     //현재 오브젝트가 mv3_initPos위치로 11f의 속력으로 가는 함수
    }
    private void OnTriggerStay2D(Collider2D collision){
        if (Input.GetMouseButtonUp(0)){                                                                                //화면에서 마우스 클릭을 떼면
            if (collision.tag == this.tag){                                                                            //충돌체의 태그와 현재 오브젝트의 태그가 같다면
                Destroy(this.gameObject); 
                mg_SoundManager.GetComponent<SoundManager>().playSound("Match2");   // 정답이 맞으면 소리가 나게 한다                                                                             //현재 오브젝트 없애기  
                mgo_GameControl.GetComponent<CheckAnswerEpi3>().v_CountAnswer();                                       //정답 개수를 올려주기 위한 함수 실행
            }
        }
    }
}
