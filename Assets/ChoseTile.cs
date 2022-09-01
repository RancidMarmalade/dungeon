using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseTile : MonoBehaviour
{
    private int GenTurn;
    private float choseTile;
    private float RotOffset;
    public bool Enabled;

    public GameObject TilePillars;
    public GameObject TileStraight;
    public GameObject TileTurn;
    public GameObject SpawnPoint;
    public GameObject TileCross;
    public GameObject TileJoin;
    public GameObject TileEnd;
    
    // Start is called before the first frame update
    void Start()
    {
        GenTurn = 0;
        if(GameObject.Find("CreateMap").GetComponent<MapController>().TileCount > GameObject.Find("CreateMap").GetComponent<MapController>().MaxTiles * 0.8 && GameObject.Find("CreateMap").GetComponent<MapController>().TileCount < GameObject.Find("CreateMap").GetComponent<MapController>().MaxTiles * 0.805)
        {
            GenTurn = 2;
        }else if(GameObject.Find("CreateMap").GetComponent<MapController>().TileCount > GameObject.Find("CreateMap").GetComponent<MapController>().MaxTiles * 0.7)
        {
            GenTurn = 1;
        }

        if(Enabled == true)
        {
            
            int x = 0;
            GameObject[] Spawners = GameObject.FindGameObjectsWithTag("Spawner");

            if (GameObject.Find("CreateMap").GetComponent<MapController>().TileCount < GameObject.Find("CreateMap").GetComponent<MapController>().MaxTiles)
            {
                foreach (GameObject Spawner in Spawners)
                {
                    if (Spawner.gameObject != this.gameObject)
                    {
                        if (Vector3.Distance(this.transform.position, Spawner.transform.position) <= 1f)
                        {
                            x++;
                        }
                    }

                }

                if (x == 0)
                {
                    SpawnTile();
                }
                else
                {
                    return;
                }
            }
        }
        
    }
    public void SpawnTile()
    {
        
        choseTile = Random.Range(0, 101);
        choseTile = choseTile / 100;
        
        if(choseTile < 0.1f && GenTurn == 0)
        {
            InstantiateCross();
            
        }
        else if(choseTile < 0.2f && GenTurn == 0) 
        {
            InstantiateJoin();
        }
        else if (choseTile < 0.5f && GenTurn == 0)
        {
            InstantiateTurn();
        }
        else if(choseTile < 0.7f && GenTurn == 0)
        {
            InstantiateStraight();
        }
        else if(GenTurn == 0)
        {
            InstantiatePillars();
        }
        else if(GenTurn == 1)
        {
            InstantiateTurn();
        } else
        {
            Debug.Log("END");
            InstantiateEnd();
        }
      
        GameObject.Find("CreateMap").GetComponent<MapController>().TileCount++;
    }

    public void InstantiateJoin()
    {
        RotOffset = Random.Range(0, 101);
        RotOffset = RotOffset / 100;

        if (RotOffset < 0.15f)
        {
            RotOffset = 0.00000f;
        }
        else if (RotOffset < 0.66f)
        {
            RotOffset = 90.00000f;
        }
        else
        {
            RotOffset = 180.00000f;
        }
        
        GameObject Tile = Instantiate(TileJoin, SpawnPoint.transform.position, transform.rotation);
        Tile.transform.Rotate(0, RotOffset, 0);
    }
    public void InstantiateCross()
    {
        Instantiate(TileCross, SpawnPoint.transform.position, transform.rotation);
    }
    public void InstantiateTurn()
    {
        RotOffset = Random.Range(0, 101);
        RotOffset = RotOffset / 100;

        if(RotOffset < 0.5f)
        {
            RotOffset = 90f;
        }
        else
        {
            RotOffset = 0f;
        }
        GameObject Tile = Instantiate(TileTurn, SpawnPoint.transform.position, transform.rotation);
        Tile.transform.Rotate(0, RotOffset, 0);
    }

    public void InstantiateStraight()
    {
        RotOffset = 90f;
        GameObject Tile = Instantiate(TileStraight, SpawnPoint.transform.position, transform.rotation);
        Tile.transform.Rotate(0, RotOffset, 0);
    }
    public void InstantiatePillars()
    {
        Instantiate(TilePillars, SpawnPoint.transform.position, transform.rotation);
    }

    public void InstantiateEnd()
    {

        RotOffset = 90f;
        GameObject Tile = Instantiate(TileEnd, SpawnPoint.transform.position, transform.rotation);
        Tile.transform.Rotate(0, RotOffset, 0);
    }
}
