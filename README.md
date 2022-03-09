# NFT Game
## 請使用UTF-8編碼開啟

## cookie 202203/02 ～ 2022/03/08
- 新增敵人血條
- 把黃金雞變成prefab物件
- 新增EnemyCreater負責生成敵人物件
- 預設交易程式碼做在EntryControllor的enemyNum變數
- 利用PlayerPrefs儲存在Entry中拿到的變數，在場景2生成時使用
- 將場景分離為多個，分別為init, backgroud1, backgroud2，在左上方Build Settings可調整其順序
- 會先利用init生成player，在把場景切為backgroud
- 玩家移動在playerControllor, 入口及出口在entryControllor, 敵人在enermyControllor

## cookie 2022/02/24 ~ 2022/02/28
1. 新增腳色攻擊動畫
2. 新增自製很廢的腳色站立動畫 (原本要使用unity論壇的素材包但用起來有些問題，之後再嘗試)
3. 增加黃金雞的碰撞
4. 將腳色的z軸鎖定，因其物件內設定會沿著黃金雞旋轉，先暫時這樣解決
5. 部份加上註解
6. 加上上下移動
7. 把rigidbody 2d的gravity scale調整為0，不然他會受重力一直下掉
8. 新增及替換一些素材

## 日誌
- 2022/03/08
  - 將NFT改為使用ipfs取得圖片
  - 修改EnemyController所發送的交易方法
- 2022/03/04
  - 修改程式碼遵循"[C# at Google Style Guide](https://google.github.io/styleguide/csharp-style.html)"
  - 修改發送交易的程式架構
- 2022/03/01
  - 新增與敵人互動時發送交易
- 2022/02/27
  - 遊戲一開始對自動讀取NFT(顯示當前玩家所持有，沒有則不顯示)並指顯示在場景一
  - 由場景一移動至場景二或場景二移動至場景一時會發送contract(moveStie(uint8 nextSite))
    - 1: 場景一
    - 2: 場景二
  - 發送transaction期間會等至交易完成才切換地圖
  - 當玩家重新遊玩遊戲時，會在啟動遊戲一開始讀取玩家最後離開的地圖
  - 若玩家為第一次遊玩會先初始化玩家且玩家會出現在場景一
- 2022/02/22
  - 使用方向鍵左右來移動玩家方塊(正方形)
  - 綠色背景為場景一，持續往左碰到邊屆時會進入到場景二
  - 場景二會出現敵人(菱形)，背景顏色改為紅色
  - 玩家位置會從畫面右手方繼續移動
  - 場景二繼續往左時，將不會切換場景，往又碰到邊界時會回到場景一
  - 玩家位置會從畫面左手方繼續移動
  - 按鍵K會使敵人消失
