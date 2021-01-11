namespace AnchorSystem.Core.Exceptions
{
    /// <summary>
    /// ApiErrorCode
    /// </summary>
    public enum ApiErrorCode
    {
        Success,

        #region 1 数据异常 新建 编辑 删除时

        /// <summary>
        /// 数据重复
        /// </summary>
        DataDuplication = 1001,

        /// <summary>
        /// 提交数据有误
        /// </summary>
        Submittingdataincorrect = 1002,

        /// <summary>
        /// 数据不存在 修改或者删除时 触发
        /// </summary>
        Datadoesnotexist = 1003,

        /// <summary>
        /// 新增账号时失败
        /// </summary>
        CreateUserFailed = 1004,

        /// <summary>
        /// 更新账号页面权限时失败
        /// </summary>
        EditUserPagePerFailed = 1005,

        /// <summary>
        /// 更新账号密码时失败
        /// </summary>
        ChangePasswordFailed = 1006,

        /// <summary>
        /// 更新会员账号密码时失败
        /// </summary>
        ChangeVipPasswordFailed = 1007,

        #endregion

        #region 2 登陆错误

        /// <summary>
        /// 登陆失败 
        /// </summary>
        LoginFailed = 2001,

        /// <summary>
        /// 登陆已经失效 
        /// </summary>
        LoginExpired = 2002,

        /// <summary>
        /// 无效白名单 
        /// </summary>
        UnauthorizedIp = 2003,

        /// <summary>
        /// 验证码无效 
        /// </summary>
        InvalidTwoFactor = 2004,

        /// <summary>
        /// 需要验证码 
        /// </summary>
        NeedTwoFactor = 2005,

        /// <summary>
        /// 无效的域名 
        /// </summary>
        InvalidDomain = 2006,

        /// <summary>
        /// 账号类型错误
        /// </summary>
        UserTypeError = 2007,

        /// <summary>
        /// 登陆失败次数过多,账号已锁定
        /// </summary>
        LockedOut = 2008,

        /// <summary>
        /// 极验验证错误
        /// </summary>
        GeeTestError = 2009,

        /// <summary>
        /// 账号不存在
        /// </summary>
        账号不存在 = 2010,
        邮箱已存在 = 2017,
        手机号已存在 = 2018,
        银行卡绑定数最大 = 2019,
        会员不存在 = 2020,
        操作人错误 = 2021,
        扣除金额不能大于订单金额 = 2022,
        更新账号密码失败 = 2023,
        角色不存在 = 2024,
        密码错误 = 2025,
        订单不存在 = 2026,
        订单已确认 = 2027,
        订单已通知成功 = 2028,
        订单未确认 = 2029,
        请在确认收款五分钟后操作 = 2030,
        支付回调失败 = 2031,
        操作被拒绝 = 2032,
        订单正在通知 = 2034,
        已取消订单不能确认 = 2035,
        #endregion

        域名格式不正确 = 3001,
        域名不存在 = 3002,
        域名已存在 = 3003,
        验证码无效 = 3005,
        已绑定双重验证 = 3006,
        域名未绑定 = 3008,
        白名单未添加 = 3009,
        支付接口名称已存在 = 3010,
        域名已停用 = 3011,
        支付接口编号已存在 = 3012,
        两部验证未绑定 = 3013,
        两部验证未通过 = 3014,

        #region 支付订单
        签名错误 = 5001,
        不支持的支付方式 = 5002,
        商户不存在 = 5003,
        商户不能为空 = 5004,
        签名不能为空 = 5005,
        回调地址不能为空 = 5006,

        请求通道时出错 = 5007,
        没有可用的支付通道 = 5008,
        商户订单不存在 = 5009,
        提交金额错误 = 5010,
        通道已停用 = 5011,
        接口费率不存在 = 5012,
        时间戳必须为10位数 = 5013,
        签名失效 = 5014,
        卡商余额不足 = 5015,
        卡商未开通余额 = 5016,
        支付接口配置错误 = 5017,
        充值大厅不可用 = 5018,
        真实姓名不能大于50位 = 5019,
        商户会员账号最大32位 = 5020,
        会员备注最大50位 = 5021,
        订单金额范围1到999999 = 5022,
        发起存款失败 = 5023,
        回调时出错 = 5024,
        商户会员账号不能为空 = 5025,
        指定支付方式时订单金额必须大于0 = 5026,
        商户订单号不能为空 = 5027,
        回调地址不是合法的URL = 5028,
        银行卡号不能为空 = 5029,
        银行编码不能为空 = 5030,
        银行卡持卡人不能为空 = 5031,
        银行卡开户分行不能为空 = 5032,
        银行卡开户市不能为空 = 5033,
        银行卡开户省不能为空 = 5034,
        取款配置错误 = 5035,
        IP地址未添加白名单 = 5036,
        商户订单号重复 = 5037,
        不支持该银行 = 5038,
        代付未开启 = 5039,
        #endregion

        /// <summary>
        /// 未知异常
        /// </summary>
        请求服务器时出错 = 9999,

        /// <summary>
        /// 提交数据错误
        /// </summary>
        提交数据错误 = 9998,

        /// <summary>
        /// 令牌错误
        /// </summary>
        令牌错误 = 9996,

        /// <summary>
        /// 数据不存在
        /// </summary>
        数据不存在 = 9997,

        /// <summary>
        /// 请求支付通道 PaymentService_Channel_001失败
        /// </summary>

        /// <summary>
        /// 签名回调错误
        /// </summary>
        签名回调错误 = 9991,

        /// <summary>
        /// 密钥错误
        /// </summary>
        密钥错误 = 9990,

        /// <summary>
        /// 银行卡转账银行配置错误
        /// </summary>
        银行卡转账银行配置错误 = 9989,

        /// <summary>
        /// 系统支付接口不能删除
        /// </summary>
        系统支付接口不能删除 = 9988,

        /// <summary>
        /// 生成银行账号支付宝二维码错误
        /// </summary>
        生成银行账号支付宝二维码错误 = 9987,

        /// <summary>
        /// 订单已超时
        /// </summary>
        订单已超时 = 9986,

        /// <summary>
        /// 权限不足
        /// </summary>
        权限不足 = 9985,

        /// <summary>
        /// 请求上传图片接口失败
        /// </summary>
        请求上传图片接口失败 = 9984,

        /// <summary>
        /// 上传图片失败
        /// </summary>
        上传图片失败 = 9983,
    }
}
