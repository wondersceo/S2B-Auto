public class ProductInfo
{
    public string ProductName { get; set; } = "";            // 물품명
    public string Specification { get; set; } = "";          // 규격
    public string ModelName { get; set; } = "";             // 모델명
    public string Price { get; set; } = "";                 // 판매가
    public string Manufacturer { get; set; } = "";          // 제조사
    public string OriginType { get; set; } = "";           // 원산지 (국내/국외)
    public string OriginDetail { get; set; } = "";         // 원산지 상세
    public string Stock { get; set; } = "999";             // 재고수량
    public string Material { get; set; } = "";             // 소재/재질
    public string Unit { get; set; } = "";                 // 판매단위
    public string Taxation { get; set; } = "과세";          // 과세여부

    // 인증정보
    public string ChildCertNumber { get; set; } = "";      // 어린이제품인증번호
    public string ElectricCertNumber { get; set; } = "";   // 전기용품인증번호
    public string LifeCertNumber { get; set; } = "";       // 생활용품인증번호
    public string CommCertNumber { get; set; } = "";       // 방송통신인증번호

    // 이미지 관련
    public string MainImagePath { get; set; } = "";        // 기본이미지1 경로
    public string DetailImagePath { get; set; } = "";      // 상세이미지 경로
    public string DescriptionImagePath { get; set; } = ""; // 상세설명 이미지 경로

    // 배송 관련
    public bool AdditionalShippingCheck { get; set; } = false;  // 추가배송비 설정
    public string JejuShippingFee { get; set; } = "";          // 제주 배송비
    public string DeliveryPeriod { get; set; } = "15일";        // 납품가능기간
    public string ReturnFee { get; set; } = "";                // 반품배송비
}